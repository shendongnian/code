     public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpGet]
            [ValidateAntiForgeryToken]
            public ActionResult SomeAction()
            {
                return SomeOtherAction();
            }
    
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult SomeOtherAction()
            {
                return View("SomeOtherAction");
            }
        }
