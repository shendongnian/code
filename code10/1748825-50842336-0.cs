    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OpenIdConnect;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens;
    [assembly: OwinStartup(typeof(MVC_OWIN_Client.Startup))]
    namespace MVC_OWIN_Client
    {
      public class Startup
      {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = <Your app instance' identifier, must be registered in IdP>,
                Authority = <your IdP>,
                RedirectUri = <base address of your app as registered in IdP>,
                ResponseType = "id_token",
                Scope = "openid email",
                UseTokenLifetime = false,
                SignInAsAuthenticationType = "Cookies",
            });
        }
      }
    }
