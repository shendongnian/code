    using System.Configuration;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web.Helpers;
    using IdentityServer3.Core;
    using Microsoft.IdentityModel.Protocols.OpenIdConnect;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OpenIdConnect;
    using Owin;
    
    namespace MyProject
    {
        public partial class Startup
        {
            public static string AuthorizationServer => ConfigurationManager.AppSettings["security.idserver.Authority"];
    
            public void ConfigureOAuth(IAppBuilder app)
            {
                AntiForgeryConfig.UniqueClaimTypeIdentifier = Constants.ClaimTypes.Subject;
    
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                jwtSecurityTokenHandler.InboundClaimTypeMap.Clear();
    
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = "Cookies"
                });
    
                app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
                {
                    SecurityTokenValidator = jwtSecurityTokenHandler,
                    Authority = AuthorizationServer,
                    ClientId = ConfigurationManager.AppSettings["security.idserver.clientId"],
                    PostLogoutRedirectUri = ConfigurationManager.AppSettings["security.idserver.postLogoutRedirectUri"],
                    RedirectUri = ConfigurationManager.AppSettings["security.idserver.redirectUri"],
                    ResponseType = ConfigurationManager.AppSettings["security.idserver.responseType"],
                    Scope = ConfigurationManager.AppSettings["security.idserver.scope"],
                    SignInAsAuthenticationType = "Cookies",
    #if DEBUG
                    RequireHttpsMetadata = false,   //not recommended in production
    #endif
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        RedirectToIdentityProvider = n =>
                        {
                            if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.Logout)
                            {
                                var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");
    
                                if (idTokenHint != null)
                                {
                                    n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
                                }
                            }
    
                            return Task.FromResult(0);
                        },
    
                        SecurityTokenValidated = n =>
                        {
                            var id = n.AuthenticationTicket.Identity;
    
                            //// we want to keep first name, last name, subject and roles
                            //var givenName = id.FindFirst(Constants.ClaimTypes.GivenName);
                            //var familyName = id.FindFirst(Constants.ClaimTypes.FamilyName);
                            //var sub = id.FindFirst(Constants.ClaimTypes.Subject);
                            //var roles = id.FindAll(Constants.ClaimTypes.Role);
    
                            //// create new identity and set name and role claim type
                            var nid = new ClaimsIdentity(
                                id.AuthenticationType,
                                Constants.ClaimTypes.Name,
                                Constants.ClaimTypes.Role);
    
                            nid.AddClaims(id.Claims);
                            nid.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
                            nid.AddClaim(new Claim("access_Token", n.ProtocolMessage.AccessToken));
    
                            ////nid.AddClaim(givenName);
                            ////nid.AddClaim(familyName);
                            ////nid.AddClaim(sub);
                            ////nid.AddClaims(roles);
    
                            ////// add some other app specific claim
                            // Connect to you ASP.NET database for example
                            ////nid.AddClaim(new Claim("app_specific", "some data"));
    
                            //// keep the id_token for logout
                            //nid.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
    
                            n.AuthenticationTicket = new AuthenticationTicket(
                                nid,
                                n.AuthenticationTicket.Properties);
    
                            return Task.FromResult(0);
                        }
                    }
                });
    
                //app.UseResourceAuthorization(new AuthorizationManager());
            }
        }
    }
