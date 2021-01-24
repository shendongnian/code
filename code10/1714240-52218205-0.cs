    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if ((Thread.CurrentPrincipal.Identity.Name?.Length ?? 0) <= 0)
            {
                AuthenticationHeaderValue auth = actionContext.Request.Headers.Authorization;
                if (string.Compare(auth.Scheme, "Basic", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    string credentials = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(auth.Parameter));
                    int separatorIndex = credentials.IndexOf(':');
                    if (separatorIndex >= 0)
                    {
                        string userName = credentials.Substring(0, separatorIndex);
                        string password = credentials.Substring(separatorIndex + 1);
                        var userManager = new MembershipUserManager();
                        var user = userManager.FindAsync(userName, password).Result;
                        if (user != null)
                            Thread.CurrentPrincipal = actionContext.ControllerContext.RequestContext.Principal = new GenericPrincipal(new GenericIdentity(userName, "Basic"), System.Web.Security.Roles.Provider.GetRolesForUser(userName));
                    }
                }
            }
            return base.IsAuthorized(actionContext);
        }
    }
