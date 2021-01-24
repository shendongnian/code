    public class MyCustomFilter : IAsyncActionFilter
    {
        private Session _session;
        private DBContextWithUserAuditing _dbContext;
        private ITenantService _tenantService;
        public MyCustomFilter(
            Session session,
            DBContextWithUserAuditing dbContext,
            ITenantService tenantService
            )
        {
            _session = session;
            _dbContext = dbContext;
            _tenantService = tenantService;
        }
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next
            )
        {
            string userId = null;
            int? tenantId = null;
            // do stuff
            // ...
            var resultContext = await next();
        }
    }
