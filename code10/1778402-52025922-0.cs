    public void ConfigureAuth(IAppBuilder app) 
            { 
                
                var OAuthOptions = new OAuthAuthorizationServerOptions 
                { 
                    AllowInsecureHttp = true, 
                    TokenEndpointPath = new PathString("/token"), 
                    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20), 
                    Provider = new SimpleAuthorizationServerProvider() 
                }; 
     
                app.UseOAuthBearerTokens(OAuthOptions); 
                app.UseOAuthAuthorizationServer(OAuthOptions); 
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()); 
     
                HttpConfiguration config = new HttpConfiguration(); 
                WebApiConfig.Register(config); 
            } 
     
            public void Configuration(IAppBuilder app) 
            { 
                ConfigureAuth(app); 
                GlobalConfiguration.Configure(WebApiConfig.Register); 
            }
