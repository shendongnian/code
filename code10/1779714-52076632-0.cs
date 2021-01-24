    public void Configure(IApplicationBuilder app)
    {
        app.UseAuthentication();
        
        app.Use(async (ctx, next) =>
        {
            await next();
            if (ctx.Response.StatusCode == 404 && !ctx.User.Identity.IsAuthenticated)
                ctx.Response.StatusCode = 401;
        });
        
        app.UseMvc();
    }
