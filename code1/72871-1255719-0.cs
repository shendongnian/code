    namespace MyApp.Custom.Security
    {
        public class Secure : AuthorizeAttribute
        {
            /// <summary>
            /// Checks to see if the user is authenticated and has a valid session object
            /// </summary>        
            /// <param name="httpContext"></param>
            /// <returns></returns>
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                if (httpContext == null) throw new ArgumentNullException("httpContext");
    
                // Make sure the user is authenticated.
                if (httpContext.User.Identity.IsAuthenticated == false) return false;
                 
                // This will check my session variable and a few other things.
                return Helpers.SecurityHelper.IsSignedIn();
            }
        }
    }
