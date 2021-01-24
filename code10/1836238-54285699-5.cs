     public void ConfigureServices(IServiceCollection services)
     {
    	
    	IServiceProvider Services = services.BuildServiceProvider();
        var client = Services.GetRequiredService<HttpClient>();
     }
