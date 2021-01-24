    public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {           
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                ConfigureAuth(app);
            var authOptions = new OAuthBearerAuthenticationOptions()
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
            };
            app.UseOAuthBearerAuthentication(authOptions);
                app.UseWebApi(config);
            }
        }
