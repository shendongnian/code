    public class AuditHelper : IAuditHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuditHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void LogMyChangesToDatabase()
        {
            //_httpContextAccessor.HttpContext.
        }
    }
