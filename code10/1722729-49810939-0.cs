    public void Configuration(IAppBuilder app)
    {
        System.Web.Http.HttpConfiguration config = new System.Web.Http.HttpConfiguration();
        // Web API routes
        config.MapHttpAttributeRoutes();
        ConfigureOAuth(app);
        app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        app.UseWebApi(config);
    }
