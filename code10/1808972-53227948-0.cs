    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new YourDbContext();
            var booksWithChapterList =
                db.Books
                .Include(s => s.chapterLists) //I add chapterList to query, so I don't fetch another query.
                .Select(s => new BookDto// I convert them to smaller data transfer object.
                {
                    Name = s.Name,
                    Chapters = s.chapterLists.Select(w => new BookChapterDto
                    {
                        Name = w.Name
                    }).ToList()
                })
                .ToList();
            return View(booksWithChapterList);
        }
    }
