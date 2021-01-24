    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ISiteProvider siteProvider)
    {           
        app.UseRewriter(new RewriteOptions()
            .AddRedirectToHttps()
            .AddRedirect(@"^section1/(.*)", "new/$1", (int)HttpStatusCode.Redirect)
            .AddRedirect(@"^section2/(\\d+)/(.*)", "new/$1/$2", (int)HttpStatusCode.MovedPermanently)
            .AddRewrite("^feed$", "/?format=rss", skipRemainingRules: false));
    
        app.UseStaticFiles();
    
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        });
    }
