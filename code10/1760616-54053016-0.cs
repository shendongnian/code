    public void ConfigureServices(IServiceCollection services)
            {
                JwtBearerConfiguration(services);
    
                services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowCredentials();
                }));
    
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); ;
                
                
                services.AddSignalR();
    
                services.AddHostedService<HostServiceHelper>(); // <===== StartAsync is called
    
            }
