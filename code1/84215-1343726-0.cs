    [MyAuthenticate(Exempt="View")]
    public class MyController : Controller
    {
        public ActionResult Edit()
        {
            // Protected
        }
        
        public ActionResult View()
        {
            // Accessible by all
        }
    }
