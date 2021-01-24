    public class CustomAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // user not authorized, redirect to login page
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }
            
            string roleName = GetModuleName(filterContext);
            var user = filterContext.HttpContext.User;
            // Chaeck user permissions
            if (!user.IsInRole(roleName))
            {
                // Handle not authorized requests and redirect to error page
                filterContext.Result = new RedirectResult("~/Error/NotAuthorized");
                return;
            }
            
            base.OnAuthorization(filterContext);
        }
        
        string GetModuleName(AuthorizationContext filterContext)
        {
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.FullName;
            var actionName = filterContext.ActionDescriptor.ActionName;
            return controllerName; // or actionName
        }
    }
