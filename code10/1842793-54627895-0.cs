    using Owin;
    [assembly: OwinStartup(typeof(Token.API.Startup))]
    namespace Token.API
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.ConfigureAuthorization(ClaimsProviders
                        .InitializeAuthorizationProviders()
                        .IncludeAzureActiveDirectoryUserClaims()
                );
            }
        }
    }
