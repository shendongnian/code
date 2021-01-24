    public void ConfigureServices(IServiceCollection services)
    {
     services.AddDbContextPool<MCContext >(
         options => options.UseSqlServer(connectionString));
     }
