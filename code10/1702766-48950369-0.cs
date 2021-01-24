    public class AuthorizeRoleAttribute : AuthorizeAttribute
    {
        public string AccessRole { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }
            switch (AccessRole)
            {
                case "SuperUser":
                    return httpContext.User.IsInRole(Settings.Instance.SuperUserRole);
                case "User":
                    return httpContext.User.IsInRole(Settings.Instance.UserRole) || httpContext.User.IsInRole(Settings.Instance.SuperUserRole);
                case "Any":
                    return httpContext.User.IsInRole(Settings.Instance.ContributorRole) || httpContext.User.IsInRole(Settings.Instance.UserRole) || httpContext.User.IsInRole(Settings.Instance.SuperUserRole);
                default:
                    return false;
            }
        }
    }
    
