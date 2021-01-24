    public class PermissionFilterProxy<TFilter> : IAuthorizationFilter
        where TFilter : IAuthorizationFilter
    {
        private readonly Container container;
        public PermissionFilterProxy(Container container) => this.container = container;
        public void OnAuthorization(AuthorizationContext context) =>
            container.GetInstance<TFilter>().OnAuthorization(context);
    }
