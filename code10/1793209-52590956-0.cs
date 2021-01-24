    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public string Capabilities { get; set; }
    
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Check capablities here
        }
    
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Decide what to do with unauthorized requests
        }
    }
