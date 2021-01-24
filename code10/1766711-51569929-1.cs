    public void ConfigureServices(IServiceCollection services)
            {
        services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials()
                               .WithOrigins("http://localhost:4200");
                    }));
         services.AddSignalR();
    }
