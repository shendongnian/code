        public DatabaseTenantProvider(TenantsDbContext context, IHttpContextAccessor accessor)
        {
            var host = accessor.HttpContext?.Request.Host.Value;
            // ....
        }
