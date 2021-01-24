    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddDbContext<SiteDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FFInfoDB"), sqlServerOptions => sqlServerOptions.MigrationsAssembly("FFInfo.DAL")));
    }
