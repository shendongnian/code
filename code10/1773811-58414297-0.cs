        public void ConfigureServices(IServiceCollection services)
        {
	        ...
	        services.AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
                    });
	        ...
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
	        ...
	        app.UseSwagger();
	        app.UseSwaggerUI(c =>
	        {
		        c.RoutePrefix = "swagger/ui";
		        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI(v1)");
	        });
	        ...
        }
