    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://example.com"));
        });
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddConsole();
    
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
    
        // Shows UseCors with named policy.
        app.UseCors("AllowSpecificOrigin");
        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Hello World!");
        });
    }
