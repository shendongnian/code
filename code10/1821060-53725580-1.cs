    [RoutePrefix("")]
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
    
    [RoutePrefix("search")]
    public class SearchController : Controller
    {
        [Route("")]
        public ActionResult Index(string searchTerm)
        {
            return View();
        }
    }
