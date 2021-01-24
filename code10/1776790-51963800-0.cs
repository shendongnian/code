    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddCors(o => o.AddPolicy("CORSPolicy", builder =>
    	{
    		builder.AllowAnyOrigin()
    			   .AllowAnyMethod()
    			   .AllowAnyHeader()
    			   .AllowCredentials();
    	}));
    }
