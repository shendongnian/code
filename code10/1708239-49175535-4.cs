    public class CustomAuthorizationFilter : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (base.IsAuthorized(actionContext))
            {
                var authorizeAttribute = GetAuthorizeAttribute(actionContext.ActionDescriptor);
                // Attribute doesn't exist - return true
                if (authorizeAttribute == null)
                    return true;
                var roles = authorizeAttribute.CustomRoles;
                // Logic - return true if authorized, false if not authorized
            }
            return false;
        }
        private CustomAuthorizeAttribute GetAuthorizeAttribute(HttpActionDescriptor actionDescriptor)
        {
            // Check action level
            CustomAuthorizeAttribute result = actionDescriptor
                .GetCustomAttributes<CustomAuthorizeAttribute>()
                .FirstOrDefault();
            if (result != null)
                return result;
            // Check class level
            result = actionDescriptor
                .ControllerDescriptor
                .GetCustomAttributes<CustomAuthorizeAttribute>()
                .FirstOrDefault();
            return result;
        }
    }
