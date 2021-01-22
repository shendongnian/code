    [CustomAuthorize]
    public class AuthorizedControllerBase : CustomControllerBase
    {
    }
    public class OpenAccessControllerBase : CustomControllerBase
    {
    }
    public class MyRealController : AuthorizedControllerBase 
    {
        // GET: /myrealcontroller/index
        public ActionResult Index()
        {
            return View();
        }
    }
