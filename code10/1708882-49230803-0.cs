    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddMvcCore();
        ...
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseCors(builder => builder
            .WithOrigins("http://localhost:8000")
            .AllowAnyHeader()
            .AllowAnyMethod()
        );
    
        app.UseMvcCore();
        ...
    }
