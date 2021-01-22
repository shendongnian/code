    public class RequiresAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            Contract.Requires(filterContext != null);
            HttpContextBase context = filterContext.RequestContext.HttpContext;
            if (context.User.Identity.IsAuthenticated)
            {
                // user does not possess the required role permission
                string url = context.GetCustomErrorUrl(401);
                context.Response.Redirect(url);
            }
            else
            {
                // redirect the user to the login page
                string extraQueryString  = context.Request.RawUrl;
                FormsAuthentication.RedirectToLoginPage(extraQueryString);
            }
        }
    }
