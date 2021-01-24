    public void Configure(IApplicationBuilder app)
    {
        // ...
        app.UseStatusCodePagesWithReExecute("/.../{0}");
        app.Use(async (ctx, next) =>
        {
            if (ctx.Request.Path.Value.StartsWith("/api", StringComparison.OrdinalIgnoreCase))
            {
                var statusCodeFeature = ctx.Features.Get<IStatusCodePagesFeature>();
                
                if (statusCodeFeature != null && statusCodeFeature.Enabled)
                    statusCodeFeature.Enabled = false;
            }
            await next();
        });
        // ...
        app.UseMvc();
        // ...
    }
