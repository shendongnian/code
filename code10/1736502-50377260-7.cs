    // Dashboard controller. I know you have home controller inside 
    // your admin area but they should work the same.
    namespace DL.SO.Web.UI.Areas.Admin.Controllers
    {
        public class DashboardController : AdminControllerBase
        {
            public IActionResult Index()
            {
               return View();
            }
        }
    }
    // Users controller. I know you have User(s) controller but I usually
    // just keep the name of the controller singular.
    namespace DL.SO.Web.UI.Areas.Admin.Controllers
    {
        public class UserController : AdminControllerBase
        {
            public IActionResult Index()
            {
                return View();
            }
        }
    }
