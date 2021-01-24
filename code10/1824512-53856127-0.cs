    public class VBAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            // …
    
            await something;
    
            // …
        }
    }
