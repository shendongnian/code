    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddCors(options =>
    	{
    		options.AddPolicy("MyCorsPolicy", builder => builder
    			.AllowAnyOrigin()
    			.AllowAnyMethod()
    			.WithHeaders("Accept", "Content-Type", "Origin", "X-My-Header"));
    	});
    }
