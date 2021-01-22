    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
           //httpContext.Request.Form["groupid"]
            return base.AuthorizeCore(httpContext);
        }
    }
