    public void Configure(IApplicationBuilder app, IHostingEnvironment env, YourDbContext dbContext)
    {
       // other configurations
       ..............
       DatabaseInitializer.Initialize(dbContext);
       ..............
       // other configurations
    }
