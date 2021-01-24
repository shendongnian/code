    public class MyAuthorizeFilter: IAsyncAuthorizationFilter
    {
        public MyAuthorizeFilter(string policy)
        {
            Policy = policy;
        }
        public string Policy { get; set; }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            var authZService = context.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
            var accessable = await authZService.AuthorizeAsync(user, null, this.Policy);
            if (!accessable.Succeeded)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
           
        }
    }
