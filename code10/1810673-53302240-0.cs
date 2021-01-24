    public void Configuration(IAppBuilder app) {    
        HttpConfiguration config = new HttpConfiguration();
        UnityConfig.Register(config);
        WebApiConfig.Register(config);
        ConfigureOAuth(app, config.DependencyResolver);
        app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        app.UseWebApi(config);
    }
    
    public void ConfigureOAuth(IAppBuilder app, IDependencyResolver resolver) {
        OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions() {
            AllowInsecureHttp = true,
            TokenEndpointPath = new PathString("/api/token"),
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
            Provider = new SimpleAuthorizationServerProvider((IAuthRepository)resolver.GetService(typeof(IAuthRepository)))
        };
        app.UseOAuthAuthorizationServer(OAuthServerOptions);
        app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());    
    }
