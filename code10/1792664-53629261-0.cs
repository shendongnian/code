    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddCors(options => options.AddPolicy("MyCorsPolicy",
    		builder => builder.AllowAnyOrigin()
    			.AllowAnyMethod()  // ..or you can use .WithMethods("GET","POST","PUT","DELETE", "PATCH")
    			.AllowAnyHeader()
    			.AllowCredentials()
    			.Build()));
    }
