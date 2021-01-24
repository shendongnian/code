    public class SomeService : ISomeService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public SomeService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        public void SomeMethod()
        {
            var httpContext = _contextAccessor.HttpContext;
        }
    }
