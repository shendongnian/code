    public class PermissionFilterProxy : IAuthorizationFilter
    {
        private readonly IServiceProvider ServiceProvider;
        public PermissionFilterProxy(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
        public void OnAuthorization(AuthorizationContext context)
        {
            var filter = (PermissionFilter)ServiceProvider.GetService(typeof(PermissionFilter));
            filter.OnAuthorization(context);
        }
    }
