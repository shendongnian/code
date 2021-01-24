    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Error()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult PageNotFound()
        {
            return View();
        }
    }
