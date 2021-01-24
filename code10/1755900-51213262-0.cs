    public class Startup
    {
      public void Configuration(IAppBuilder app)
      {
        // turn off any default mapping on the JWT handler
        JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
        app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44333/core",
                RequiredScopes = new[] { "api1" }
            });
        app.UseWebApi(WebApiConfig.Register());
      }
    }
