    public class MyController : Controller{
        public ActionResult Index()
        {
            using (var db = new Models())
            {
                var foo = db.Foo.ToList();
                return View(foo);
            }
        }
    }
