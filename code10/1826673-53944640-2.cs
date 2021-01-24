    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Action1()
        {
            return Content("Action 1 result.");
        }
        [HttpGet]
        public ActionResult Action2()
        {
            return Content("Action 2 result.");
        }
    }
