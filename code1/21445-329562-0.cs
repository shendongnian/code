    [AdminAuthorize (Roles = "Administrator", Exempt = "Login, Logout") ]
    public class AdminController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        ... other, restricted actions ...
    }
