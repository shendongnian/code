    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
    {
        // ...
    
        app.Use(async (context, next) =>
        {
            await next();
    
            if (context.Response.StatusCode == (int)System.Net.HttpStatusCode.Unauthorized)
            {
                logger.LogWarning("Unauthorized request");
            }
        });
        app.UseAuthentication();
        // ...
    }
