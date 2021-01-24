    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.Configure<DatabaseOptions>(Configuration.GetSection("DatabaseOptions"));
    }
