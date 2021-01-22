    public class MyCustomAuthorizeAttribute : AuthorizeAttribute
    {
        public IAuthorizationService _authorizationService = new MyAuthorizationService();
 
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
           return _authorizationService.Authorize(httpContext);
        }
    }
