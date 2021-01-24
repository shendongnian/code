        public class BaseAuthorizeFilter : IAuthorizationFilter, IActionFilter
    {
        public ClaimsIdentity _User;
        public IHttpContextAccessor _accessor;
        public BaseAuthorizeFilter(IUserResolverService userService, IHttpContextAccessor accessor)
        {
            _User = userService.GetUser();
            _accessor = accessor;
        }
