    public class LocalPermittedAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                return (httpContext.Request.IsLocal || base.AuthorizeCore(httpContext)));
            }
    }
