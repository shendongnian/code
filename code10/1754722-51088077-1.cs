    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor accessor;
        public UserContext(IHttpContextAccessor accessor) => this.accessor = accessor;
        public string UserName => this.accessor.HttpContext.User.Identity.Name;
    }
