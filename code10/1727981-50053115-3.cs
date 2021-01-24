    public static class HttpClientExtensions
        {
            public static async void AddBearerToken(this HttpClient client, HttpContext context)
            {
                var accessToken = await context.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
    
                if (!string.IsNullOrWhiteSpace(accessToken))
                    client.SetBearerToken(accessToken);
            }
    
            public static async Task<string> RefreshTokensAsync(this HttpClient client, HttpContext context)
            {
                var discoveryResponse = await DiscoveryClient.GetAsync(Constants.Authority);                                                  // Retrive metadata information about our IDP
    
                var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, Constants.ClientMvc.Id, Constants.ClientMvc.Secret);       // Get token client using the token end point. We will use this client to request new tokens later on
    
                var refreshToken = await context.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);                                     // Get the current refresh token
    
                var tokenResponse = await tokenClient.RequestRefreshTokenAsync(refreshToken);                                                 // We request a new pair of access and refresh tokens using the current refresh token
    
                if (tokenResponse.IsError)                                                                                                    // Let's the unauthorized page bubbles up instead doing throw new Exception("Problem encountered while refreshing tokens", tokenResponse.Exception)
                    return null;
    
                var expiresAt = (DateTime.UtcNow + TimeSpan.FromSeconds(tokenResponse.ExpiresIn)).ToString("O", CultureInfo.InvariantCulture); // New expires_at token ISO 860
    
                var authenticateResult = await context.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);                  // HttpContext.Authentication.GetAuthenticateInfoAsync() deprecated
    
                authenticateResult.Properties.UpdateTokenValue(OpenIdConnectParameterNames.AccessToken, tokenResponse.AccessToken);           // New access_token
                authenticateResult.Properties.UpdateTokenValue(OpenIdConnectParameterNames.RefreshToken, tokenResponse.RefreshToken);         // New refresh_token 
                authenticateResult.Properties.UpdateTokenValue(Constants.Tokens.ExpiresAt, expiresAt);                                        // New expires_at token ISO 8601
    
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, authenticateResult.Principal, authenticateResult.Properties); // Signing in again with the new values, doing such a user relogin, ensuring that we change the cookies on client side. Doig so the user that has logged in has the refreshed tokens
    
                return tokenResponse.AccessToken;
            }
    
    
            public static async Task RevokeTokensAsync(this HttpClient client, HttpContext context)
            {
                var discoveryResponse = await DiscoveryClient.GetAsync(Constants.Authority);                                                                // Retrive metadata information about our IDP
    
                var revocationClient = new TokenRevocationClient(discoveryResponse.RevocationEndpoint, Constants.ClientMvc.Id, Constants.ClientMvc.Secret); // Get token revocation client using the token revocation endpoint. We will use this client to revoke tokens later on
    
                var accessToken = await context.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);                                                     // Get the access token token to revoke
    
                if (!string.IsNullOrWhiteSpace(accessToken))
                {
                    var revokeAccessTokenTokenResponse = await revocationClient.RevokeAccessTokenAsync(accessToken);
    
                    if (revokeAccessTokenTokenResponse.IsError)
                        throw new Exception("Problem encountered while revoking the access token.", revokeAccessTokenTokenResponse.Exception);
                }
    
                var refreshToken = await context.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);                                                   // Get the refresh token to revoke
    
                if (!string.IsNullOrWhiteSpace(refreshToken))
                {
                    var revokeRefreshTokenResponse = await revocationClient.RevokeRefreshTokenAsync(refreshToken);
    
                    if (revokeRefreshTokenResponse.IsError)
                        throw new Exception("Problem encountered while revoking the refresh token.", revokeRefreshTokenResponse.Exception);
                }
            }
    
        }
