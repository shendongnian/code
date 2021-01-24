    services.AddAuthentication(options =>
                    {
                        options.DefaultScheme = "Cookies";
                        options.DefaultChallengeScheme = "oidc";
                    })
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                    {
                        options.Events = new CookieAuthenticationEvents
                        {
                            OnValidatePrincipal = async x =>
                            {
                                var now = DateTimeOffset.UtcNow;
                                var timeElapsed = now.Subtract(x.Properties.IssuedUtc.Value);
                                var timeRemaining = x.Properties.ExpiresUtc.Value.Subtract(now);
    
                                if (timeElapsed > timeRemaining)
                                {
                                    var discoveryResponse = await DiscoveryClient.GetAsync(gatewaySettings.IdentitySeverAddress);
                                    if (discoveryResponse.IsError)
                                    {
                                        throw new Exception(discoveryResponse.Error);
                                    }
    
                                    var identity = (ClaimsIdentity) x.Principal.Identity;
                                    var accessTokenClaim = identity.FindFirst("access_token");
                                    var refreshTokenClaim = identity.FindFirst("refresh_token");
    
                                    var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, "MyApi", "secret");
    
                                    var refreshToken = refreshTokenClaim.Value;
    
                                    var tokenResponse = await tokenClient.RequestRefreshTokenAsync(refreshToken);
    
                                    if (!tokenResponse.IsError)
                                    {
                                        identity.RemoveClaim(accessTokenClaim);
                                        identity.RemoveClaim(refreshTokenClaim);
    
                                        identity.AddClaims(new[]
                                        {
                                            new Claim("access_token", tokenResponse.AccessToken),
                                            new Claim("refresh_token", tokenResponse.RefreshToken)
                                        });
                                        x.ShouldRenew = true;
                                    }
                                }
                            }
                        };
                    })
