    services.AddCors(options =>
                {
                    options.AddPolicy("CorsAllowAll",
                        builder =>
                        {
                            builder
                            .AllowAnyOrigin() 
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                        });                    
    
                    options.AddPolicy("CorsAllowSpecific",
                        p => p.WithHeaders("Content-Type","Accept","Auth-Token")
                            .WithMethods("POST","PUT","DELETE")
                            .SetPreflightMaxAge(new TimeSpan(1728000))
                            .AllowAnyOrigin()
                            .AllowCredentials()
                        ); 
                });
