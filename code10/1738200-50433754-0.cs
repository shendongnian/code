    class MyContext : DbContext
    {
        private readonly IDbContextConfigurator _dbContextConfigurator;
        public MyContext(DbOptions<MyContext> dbOptions, IDbContextConfigurator dbContextConfigurator)
            : base(dbOptions)
        {
            _dbContextConfigurator = dbContextConfigurator;
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _dbContextConfigurator.Configure(modelBuilder);
        }
    }
