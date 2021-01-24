    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddMvc();
    
    	services.Configure<MyAppConfig>(Configuration);
    }
