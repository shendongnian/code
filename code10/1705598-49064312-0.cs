    app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
    app.UseCookieAuthentication(new CookieAuthenticationOptions()
                {
                   
                    AuthenticationType = "Cookies",
                    AuthenticationMode= AuthenticationMode.Active,
                    CookieName="XXXXX",
                    CookieDomain= _cookiedomain,
                    /* you can go with default cookie encryption also */
                    TicketDataFormat = new TicketDataFormat(_x509DataProtector),
                    SlidingExpiration = true,
                    CookieSecure = CookieSecureOption.Always,
                });
    app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
                {
    
                    ClientId = _clientID,
                    Authority = _authority,
                    RedirectUri = _redirectUri,
                    UseTokenLifetime = false,
                    
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
    
                        SecurityTokenValidated = SecurityTokenValidated,
    
                        AuthenticationFailed = (context) =>
                        {
                            /* your logic to handle failure*/
                        }
                    },
   
                    TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidIssuers = _validIssuers,
                        ValidateIssuer = _isValidIssuers,
                    }
                });
