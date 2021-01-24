    public class NgController : Controller
    {
        private boolean Authenticated()
        {
            // returns true if the user is authenticated. This system can
            // (and probably should) be integrated or replaced with
            // one of the ASP.NET Core authentication modules.
            return true;
        }
        public ActionResult Index()
        {
            if (!Authenticated())
                return RedirectToAction("Login", "Authentication", new { ReturnUrl = HttpContext?.Request?.Path });
            // Index does not serve directly the app: redirect to default one
            return RedirectToAction("TheApp");
        }
        // One action for each SPA in your installment
        public ActionResult TheApp() => UiSinglePageApp("TheApp");
        public ActionResult AnotherSPA() => UiSinglePageApp("AnotherSPA");
        // The implementation of every SPA action is reusable
        private ActionResult UiSinglePageApp(string appName)
        {
            if (!Authenticated())
                return RedirectToAction("Login", "Authentication", new { ReturnUrl = HttpContext?.Request?.Path });
            return View("Ui", new SinglePageAppModel { AppName = appName });
        }
    }
