    // Custom Base controller.
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Do whatever here...
        }
    }
    
    // Account controller.
    public class AccountController : BaseController
    {
        // Action methods here...
    }
