    // Put this here to apply to all pages in this controller
    [IPFilter]
    public class TestController : Controller
    {
        // Or here to only affect the index page
        [IPFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
