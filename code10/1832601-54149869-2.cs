    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        app.UseCors(
            options => options.WithOrigins("http://example.com").AllowAnyMethod()
        );
    
        app.UseMvc();
    }
