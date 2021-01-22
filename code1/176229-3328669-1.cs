    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = base.Session.SessionID;
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
