     public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpGet]
            [ValidateAntiForgeryToken]
            public ActionResult SomeOtherAction()
            {
                return SomeAction();
            }
    
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult SomeAction()
            {
                return View("SomeAction");
            }
        }
