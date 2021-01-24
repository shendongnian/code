    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.DataHandler.Encoder;
    using Microsoft.Owin.Security.Jwt;
    using Microsoft.Owin.Security.OAuth;
    using Owin;
    using System;
    using System.Configuration;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web.Http;
    using TempPerson.Models;
    using System.Linq;
    using System.IdentityModel.Tokens.Jwt;
    using Thinktecture.IdentityModel.Tokens;
    using Microsoft.IdentityModel.Tokens;
    
    [assembly: OwinStartup(typeof(TempPerson.Startup))]
    namespace TempPerson
    {
        public partial class Startup
        {
            
            public void Configuration(IAppBuilder app)
            {
    
                var config = new HttpConfiguration();
    
                ConfigureOAuth(app);
                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            }
    
            public void ConfigureOAuth(IAppBuilder app)
            {
                var oAuthServerOptions = new OAuthAuthorizationServerOptions()
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/login"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                    Provider = new AuthorizationServerProvider(),
                    AccessTokenFormat = new CustomJwtFormat("http://localhost:62343")
    
                };
    
                app.UseOAuthAuthorizationServer(oAuthServerOptions);
    
    
                var issuer = "http://localhost:62343";
                var audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
                var audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);
    
              app.UseJwtBearerAuthentication(
                    new JwtBearerAuthenticationOptions
                    {
                        AuthenticationMode = AuthenticationMode.Active,
                        AllowedAudiences = new[] { audienceId },
                        IssuerSecurityKeyProviders = new IIssuerSecurityKeyProvider[]
                        {
                            new SymmetricKeyIssuerSecurityKeyProvider(issuer, audienceSecret)
                        }
    
                    });
            }
        }
    
        public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
        {
            public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
            {
                context.Validated();
            }
    
            public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
    
                try
                {
                    context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
    
                             DB_PersonSpecificationsEntities db = new DB_PersonSpecificationsEntities();
                   var user =  db.Users.Where(d => d.UserName == context.UserName).FirstOrDefault();
                    if(user == null)
                    {
                        context.SetError("Error Message");
                        context.Rejected();
                        return;
                    }
                    var x = new Microsoft.AspNet.Identity.PasswordHasher().VerifyHashedPassword(user.Password, context.Password);
                   if(x.ToString() != "Success")
                    {
                        context.SetError("Error Message");
                        context.Rejected();
                        return;
                    }
                    var identity = new ClaimsIdentity("JWT");
    
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                    var ticket = new AuthenticationTicket(identity,null);
                    context.Validated(ticket);
                }
                catch (Exception ex)
                {
                    context.SetError("invalid_grant", "message");
                }
            }
    
        }
    
        public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
        {
            private readonly string _issuer;
            public CustomJwtFormat(string issuer)
            {
                _issuer = issuer;
            }
    
    
            public string Protect(AuthenticationTicket data)
            {
                if (data == null)
                {
                    throw new ArgumentNullException("data");
                }
    
                string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
    
                string symmetricKeyAsBase64 = ConfigurationManager.AppSettings["as:AudienceSecret"];
    
                var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);
                var key = new SymmetricSecurityKey(keyByteArray);
                var signingKey = new HmacSigningCredentials(keyByteArray);
                var signingKey2 = new SigningCredentials(key, "HS256");// 
    
                var issued = data.Properties.IssuedUtc;
    
                var expires = data.Properties.ExpiresUtc;
    
                var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime,signingKey2);
    
                var handler = new JwtSecurityTokenHandler();
    
                var jwt = handler.WriteToken(token);
    
                return jwt;
            }
    
            public AuthenticationTicket Unprotect(string protectedText)
            {
                throw new NotImplementedException();
            }
        }
    }
