    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        ...
    
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action=Index}/{id?}");
        });
        //Added this to redirect to Identity Server auth prior to loading SPA    
        app.Use(async (context, next) =>
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                await context.ChallengeAsync("Identity.Application");
            }
            else
            {
                await next();
            }
        });
    
        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "ClientApp";
    
            if (env.IsDevelopment())
            {
                spa.UseAngularCliServer(npmScript: "start");
            }
        });
    } 
