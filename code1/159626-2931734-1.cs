    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new LanguageModel());
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(LanguageModel data)
        {
            return View(data);
        }
    }
