    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using System.Web;
    using System.Web.Mvc;
    public class BaseController : Controller
    {
        protected ApplicationUser CurrentUser
        {
            get { return System.Web.HttpContext.Current.GetOwinContext()
                        .GetUserManager<ApplicationUserManager>()
                        .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()); 
                }
        }
    
        //...
    }
