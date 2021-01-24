    public class HomeController : Controller
    {
    
        public ActionResult Index()
        {
            return RedirectPermanent("/shopping");
        }
    }
