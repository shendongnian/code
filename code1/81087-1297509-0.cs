    namespace YourApplication.Controllers
    {
        public abstract class ApplicationController : Controller
        {
            public ApplicationController()
            {
                using(ApplicationDataContext menu = new ApplicationDataContext())
                {
                    // loading data for menu control
                    MenuRepository myMenu = new MenuRepository();
                    ViewData["menu"] = myMenu.MenuList();
                }
            }
        }
    }
