    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
        public class VBAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter {
            public void OnAuthorization(AuthorizationFilterContext context) {
                var sessionManager = (VBSessionManager)context.HttpContext.RequestServices.GetService(typeof(VBSessionManager));
                var user = sessionManager.GetCurrentSessionAsync().Result;
                if (user == null) {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
        }
