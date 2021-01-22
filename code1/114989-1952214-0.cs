    public class HomeController : Controller
    {
    
        public ActionResult Index()
        {
            return View();
        }
    
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FetchData()
        {
            return Content("Some data...");
        }
    
    }
