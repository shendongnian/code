    public class MyController : Controller
    {
        public ActionResult Index()
        {
            using (Models db = new Models())
            {
                var foo = (from f in db.foo select f).ToList();
                return View(foo);
            }
        }
    }
