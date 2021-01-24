    public class MyAuthorizeFilter: IAsyncAuthorizationFilter
    {
        public MyAuthorizeFilter(string policy)
        {
            this.Policies = string.IsNullOrEmpty(policy) ?
            new List<string>() :
            policy.Split(",").Select(p => p.Trim()).ToList();
        }
        public IList<string> Policies { get; set; }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            var authZService = context.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
            var accessable = await authZService.AuthorizeAsync(user, this.Policies, "MyPolicy");
            if (!accessable.Succeeded)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
           
        }
    }
