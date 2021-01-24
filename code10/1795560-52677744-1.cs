    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new SimpleModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(SimpleModel model)
        {
            return View(model);
        }
    }
