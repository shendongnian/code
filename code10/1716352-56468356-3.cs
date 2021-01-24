    public class Auth
        {
            public static void ConfigureForMvc(IAppBuilder app)
            {
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Login"),
                    
                    Provider = new CookieAuthenticationProvider
                    {
                        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, UserEntity, int>(
                            validateInterval: TimeSpan.FromMinutes(30),
                            regenerateIdentityCallback: (manager, user) =>
                            user.GenerateUserIdentityAsync(manager, DefaultAuthenticationTypes.ApplicationCookie),
                            getUserIdCallback: (Identity) => Identity.GetUserId<int>())
                    }
                });
            }
    
            public static void ConfigureForApi(IAppBuilder app)
            {
                var OAuthServerOptions = new OAuthAuthorizationServerOptions()
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/oauth2/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(120),
                    Provider = new CustomOAuthProvider(),
                    AccessTokenFormat = new CustomJwtFormat(ConfigConstants.Issuer)
                };
    
                app.UseOAuthAuthorizationServer(OAuthServerOptions);
    
                app.UseJwtBearerAuthentication(
                    new JwtBearerAuthenticationOptions
                    {
                        AuthenticationMode = AuthenticationMode.Active,
                        AllowedAudiences = new[] { ConfigConstants.AudienceId },
                        IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                        {
                            new SymmetricKeyIssuerSecurityTokenProvider(ConfigConstants.Issuer, ConfigConstants.AudienceSecurityKey)
                        }
                    });
    
            }
        }
