    public static class MyServiceExtensions
    {
        public static DbContext GetDbContext(this Service service)
        {
            var dbContexts = service.TryResolve<IDbContexts>();
            return dbContexts.Get(service.GetSession());
        }
    }
