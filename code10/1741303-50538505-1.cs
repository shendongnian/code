    public class RequireAuthFilter : IAsyncActionFilter
    {
        private readonly Roles[] _rolesToAllow;
    
        public RequireAuthFilter(Roles[] rolesRequirement = default(Roles[]))
        {
            _rolesToAllow = rolesRequirement;
        }
    
        public async Task OnActionExecutionAsync(
        ActionExecutingContext context, 
        ActionExecutionDelegate next ) 
        {
            // Verify is Authenticated
            if (context.HttpContext.User.Identity.IsAuthenticated != true)
            {
                context.HttpContext.SetResponse(401, "User is not Authenticated");
                return;
            }
    
            var isCompanyAdmin = context.HttpContext.IsCompanyAdmin(); 
            // ^ HttpContext Extension method that looks at our JWT Token 
            // and determines if has required Cliams/Roles.
    
            if (isCompanyAdmin == true)
            {
                await next();
                return;
            } else {
              context.HttpContext.SetResponse(401, "Restricted to Company");
                    return;
            }
    
            // Other custom logic for each role.
            // You will want to decide if comma represents AND or an OR 
            // when specifying roles.
        }
    }
