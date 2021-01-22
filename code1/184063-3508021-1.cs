    [RequireHttps]
    public class SecureController : Controller
    {
        public ActionResult YourAction()
        {
            // ...
        }
    }
    // ...
    public class YourController : Controller
    {
        [RequireHttps]
        public ActionResult SecureAction()
        {
            // ...
        }
    }
