    public class RequiredPermissionAttribute : Attribute, IAsyncAuthorizationFilter{
        public RequiredPermissionAttribute(string permissions)
        {
            this.Permissions = string.IsNullOrEmpty(permissions) ?
                new List<string>():
                permissions.Split(",").Select(p =>p.Trim()).ToList();
        }
        public IList<string> Permissions {get;set;}
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            var authZService = context.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
            var accessable = await authZService.AuthorizeAsync(user,this.Permissions,"Require Permissions Policy");
            if(!accessable.Succeeded){
                context.Result =  new ForbidResult();
            }
        }
    }
