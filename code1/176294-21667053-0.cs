    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var defaultResult = base.AuthorizeCore(httpContext);
            // custom logic
            return true; // or false
        }
    }
