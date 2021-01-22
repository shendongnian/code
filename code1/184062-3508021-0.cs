    [RequireHttps]
    public class SecureController 
    {
        public ActionResult YourAction()
        {
            // ...
        }
    }
    // ...
    public class YourController
    {
        [RequireHttps]
        public ActionResult SecureAction()
        {
            // ...
        }
    }
