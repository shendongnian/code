    public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", //give it the name you want
                               builder =>
                               {
                                   builder.WithOrigins( "http://localhost:3000", //dev site
                                                        "production web site"
                                                       .AllowAnyHeader()
                                                       .AllowAnyMethod()
                                                       .AllowCredentials();
                               });
            });
    
            //database services here
    
            services.AddControllers();
        }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            // global policy same name as in the ConfigureServices()
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
