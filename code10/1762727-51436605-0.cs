    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddMvc();
    
    	//DKS: Makes the SignalR services available to the dependency injection system. 
    	services.AddCors(options => options.AddPolicy("CorsPolicy",
    	builder =>
    	{
    		builder.AllowAnyMethod().AllowAnyHeader()
    			   .WithOrigins("http://localhost:53249")
    			   .AllowCredentials();
    	}));
    
    	services.AddSignalR();
    }
