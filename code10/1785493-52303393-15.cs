    //using Microsoft.AspNetCore.Authorization;
    //using Microsoft.AspNetCore.Mvc;
    //using Microsoft.AspNetCore.Mvc.Filters;
    public class CustomPolicyAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private int _number;
    
        public CustomPolicyAttribute(int number)
        {
            _number = number;
        }
    
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var service = (IAuthorizationService)context.HttpContext.RequestServices.GetService(typeof(IAuthorizationService));
    
            var requirement = new CustomRequirement
            {
                Number = _number
            };
            var result = await service.AuthorizeAsync(context.HttpContext.User, null, requirement);
            if (!result.Succeeded)
                context.Result = new ForbidResult();
        }
    }
