    public void ConfigureServices(IServiceCollection services)
    {
      //add cors service
                    services.AddCors(options => options.AddPolicy("Cors",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                        }));
    	
    	services.AddMvc();
       	    
    	     // register an IHttpContextAccessor so we can access the current
                // HttpContext in services by injecting it
                //---we use to this pull out the contents of the request
    	
    	services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
