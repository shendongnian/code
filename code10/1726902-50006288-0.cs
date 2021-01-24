             app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    
                    
                    Notifications = new OpenIdConnectAuthenticationNotifications()
                    {
                        RedirectToIdentityProvider = (context) =>
                        {
                            
                            _redirectUri = _siteUrl + context.Request.Path;
                            
                            
                            return Task.FromResult(0);
                        },
                        // If there is a code in the OpenID Connect response, redeem it for an access token and refresh token, and store those away.
                        AuthorizationCodeReceived = async (context) =>
                        {
                            var httpContext =
                                HttpContext.Current.GetOwinContext().Environment["System.Web.HttpContextBase"] as
                                    HttpContextBase;
                            var code = context.Code;
                            context.AuthenticationTicket.Properties.RedirectUri = _redirectUri;
                           }
                        },
                        AuthenticationFailed = OnAuthenticationFailed
                    }
                });
