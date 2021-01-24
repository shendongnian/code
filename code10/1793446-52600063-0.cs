    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var oAuthOptions = new OAuthBearerAuthenticationOptions
            {
                // your jwt settings
            };
            app.UseOAuthBearerAuthentication(oAuthOptions);
            app.Use(typeof(BasicAuthenticationMiddleWare)); // basic auth middleware           
        }
    }
