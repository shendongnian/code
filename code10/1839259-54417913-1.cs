    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.Configure<MyConfig>(Configuration.GetSection("MySettings"));
    }
