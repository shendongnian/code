     public void ConfigureServices(IServiceCollection services)
        {
    
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
             .....
        }
        
    
   
