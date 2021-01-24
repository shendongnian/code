    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ....
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "Default",
                template: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = 1 });                    
        });
    }
