    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddCors(options =>
    	{
    		options.AddPolicy("MyCorsPolicy", builder => builder
                .WithOrigins("https://my.web.com", "http://localhost:5001")
        		.AllowAnyMethod()
                .AllowCredentials()
    			.WithHeaders("Accept", "Content-Type", "Origin", "X-My-Header"));
    	});
    }
