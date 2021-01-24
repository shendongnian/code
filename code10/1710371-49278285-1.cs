    [assembly: OwinStartup(typeof(WebAPI.Startup))]
    namespace WebAPI
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                HttpConfiguration config = new HttpConfiguration();
                ConfigureOAuth(app);
                WebApiConfig.Register(config);
                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
                
    
            }
            public void ConfigureOAuth(IAppBuilder app)
            {
                OAuthAuthorizationServerOptions
                 OAuthServerOptions = new OAuthAuthorizationServerOptions()
                 {
                     AllowInsecureHttp = true,
                     TokenEndpointPath = new PathString("/token"),
                     AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                     Provider=new ApplicationOAuthProvider(),
                     //AuthenticationMode = AuthenticationMode.Active
                 };
                app.UseOAuthAuthorizationServer(OAuthServerOptions);
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions {
                    Provider = new OAuthBearerAuthenticationProvider()
                }
                );
            }
        }
    }
