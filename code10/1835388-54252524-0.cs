    public void ConfigureServices(IServiceCollection services)
    {
     services.AddDbContext<MCContext >(
         options => options.UseSqlServer(connectionString));
     }
