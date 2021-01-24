    public void Configure(IApplicationBuilder app)
    {
        // basic stuff
        var config = services.GetService<IConfiguration>();
        string route = config.GetValue<string>("Path");
        app.UseMvc(routes => {
            routes.MapRoute("someName", route, new { controller = "myController", action = "myAction"});
        });
    }
