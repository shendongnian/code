       public void ConfigureServices(IServiceCollection services)
                {
                  .........................
                    services.AddCors(options =>
                            {
                                options.AddPolicy("AllowSpecificOrigin",
                                    builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());
                            });;
                     ...............
                }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<AppServerSettings> appServerSettings)
            {
                ..........
                app.UseCors("AllowSpecificOrigin");
                ..........
            }
