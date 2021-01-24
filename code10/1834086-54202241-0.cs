    public class CustomWebApplicationFactory<TStartup, TContext> : WebApplicationFactory<TStartup> 
        where TStartup : class 
        where TContext : DbContext
    {
        private readonly SeedDataClass _seed;
        public CustomWebApplicationFactory(SeedDataClass seed)
        {
            if (seed == null) throw new ArgumentNullException(nameof(seed));
            _seed = seed;
        }
    }
