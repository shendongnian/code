    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var listOfFiles = new MarketingController().GetMarketing();
    
            return View(listOfFiles);
        }
    }
