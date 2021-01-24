     Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthorizationCodeReceived = async n => {
                            var userInfoClient = new UserInfoClient(UserInfoEndpoint);
                            var userInfoResponse = await userInfoClient.GetAsync(n.ProtocolMessage.AccessToken);
    
                            var identity = new ClaimsIdentity(n.AuthenticationTicket.Identity.AuthenticationType);
                            identity.AddClaims(userInfoResponse.Claims);
    
                            var tokenClient = new TokenClient(TokenEndpoint, "portal", "secret");
                            var response = await tokenClient.RequestAuthorizationCodeAsync(n.Code, n.RedirectUri);
    
                            identity.AddClaim(new Claim("access_token", response.AccessToken));
                            identity.AddClaim(new Claim("expires_at", DateTime.UtcNow.AddSeconds(response.ExpiresIn).ToLocalTime().ToString(CultureInfo.InvariantCulture)));
                            identity.AddClaim(new Claim("refresh_token", response.RefreshToken));
                            identity.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
                            n.AuthenticationTicket = new AuthenticationTicket(identity, n.AuthenticationTicket.Properties);
    
                        },
                        RedirectToIdentityProvider = n =>
                        {
                            if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.LogoutRequest)
                            {
                                var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token").Value;
                                n.ProtocolMessage.IdTokenHint = idTokenHint;
                            }
    
                            return Task.FromResult(0);
                        }
                    }
