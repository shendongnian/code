    public class HomeController : Controller
    {       
        public ActionResult Index(Result resultop)
        {
            // do whatever you want to do with your "resultop" instance of type "Result"
            var value = resultop.loginJsonStringop;    // "VALUE_OF_FIELD"
            return View();
        }
    }
