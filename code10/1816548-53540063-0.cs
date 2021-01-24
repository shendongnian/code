    using System.Web.Mvc;
    
    namespace MODS.Filters
    {
        public class CustomAuthorizeUserAttribute : AuthorizeAttribute
        {
            // Custom property, such as Admin|User|Anon
            public string AccessLevel { get; set; }
    
            // Check to see it the user is authorized
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                System.Diagnostics.Debug.Write("Authorize Executed");  //write to debugger to test if working
                // Use Core MVC Security Model
                var isAuthorized = base.AuthorizeCore(httpContext);
                if (!isAuthorized)
                {
                    return false;
                }
                // Or use your own method of checking that the user is logged in and authorized. Returns a Boolean value.
                return MySecurityHelper.CheckAccessLevel(AccessLevel);
            }
        
            // What to do when not authorized
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Error",
                                action = "NotFound"
                            })
                        );
            }
        }
    }
