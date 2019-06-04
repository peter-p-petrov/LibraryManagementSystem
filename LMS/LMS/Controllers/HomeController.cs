using LMS.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var books = db.Books.Include(h => h.BorrowHistories)
                .Select(b => new BookViewModel
                {
                    BookId = b.BookId,
                    Author = b.Author,
                    Publisher = b.Publisher,
                    SerialNumber = b.SerialNumber,
                    Title = b.Title,
                    IsAvailable = !b.BorrowHistories.Any(h => h.ReturnDate == null)
                }).ToList();
            return View(books);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
    }
}