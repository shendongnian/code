    public class HomeController : Controller
    {
        // url is now 'index/' instead of 'home/index'
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }
        // url is now 'create/new' instead of 'home/create'
        [Route("create/new")]
        public ActionResult Create()
        {
            return View();
        }
    }
