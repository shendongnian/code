    public void ConfigureServices(IServiceCollection services)
    {
    ..
         services.AddMvc();
         services.AddTransient<IDataRepository, DataRepository>();
    ..
    }
