    public class RequiredPermission : Attribute, IAsyncAuthorizationFilter{
        public RequiredPermission(string Permissions)
        {
            this.Permissions = string.IsNullOrEmpty(Permissions) ?
                new List<string>():
                Permissions.Split(",").Select(p =>p.Trim()).ToList();
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
