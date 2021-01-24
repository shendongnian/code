    using MODS.Filters;
    
    namespace MODS.Pages.Menus
    {
        [CustomAuthorizeUser(AccessLevel = "Admin")]
        public class Admin_MainMenuModel : PageModel
        {
            public ActionResult Admin_MainMenu()
            {
                System.Diagnostics.Debug.Write("Function Executed");
                return new ViewResult();
            }
        }
    }
