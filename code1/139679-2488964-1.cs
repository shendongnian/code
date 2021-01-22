    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            //log out the error
            //string statusCode = RouteData.Values["statusCode"].ToString();
            return RedirectToAction("Index", "Home");
        }
    }
