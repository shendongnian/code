     public class CustomAuthorizeAttribute : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                string[] users = Users.Split(',');
    
                if (!httpContext.User.Identity.IsAuthenticated)
                    return false;
    
                if (users.Length > 0 &&
                    !users.Contains(httpContext.User.Identity.Name,
                        StringComparer.OrdinalIgnoreCase))
                    return false;
    
                return true;
            }
        }
