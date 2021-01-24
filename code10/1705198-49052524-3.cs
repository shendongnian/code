    public class AuthorizationFilterProxy<TFilter> : IAuthorizationFilter
        where TFilter : class, IAuthorizationFilter
    {
        private readonly Container Container;
        public AuthorizationFilterProxy(Container container)
        {
            Container = container;
        }
        public void OnAuthorization(AuthorizationContext context)
        {
            Container.GetInstance<TFilter>().OnAuthorization(context);
        }
    }
