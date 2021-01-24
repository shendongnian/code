    private async Task<TokenResponse> RenewTokensAsync()
    {
        // Initialize the token endpoint:
        var client = _httpClientFactory.CreateClient();
        var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
        if (disco.IsError) throw new Exception(disco.Error);
        // Read the stored refresh token:
        var rt = await HttpContext.GetTokenAsync("refresh_token");
        var tokenClient = _httpClientFactory.CreateClient();
        // Request a new access token:
        var tokenResult = await tokenClient.RequestRefreshTokenAsync(new RefreshTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = "mvc",
            ClientSecret = "secret",
            RefreshToken = rt
        });
        if (!tokenResult.IsError)
        {
            var old_id_token = await HttpContext.GetTokenAsync("id_token");
            var new_access_token = tokenResult.AccessToken;
            var new_refresh_token = tokenResult.RefreshToken;
            var expiresAt = DateTime.UtcNow + TimeSpan.FromSeconds(tokenResult.ExpiresIn);
            // Save the information in the cookie
            var info = await HttpContext.AuthenticateAsync("Cookies");
            info.Properties.UpdateTokenValue("refresh_token", new_refresh_token);
            info.Properties.UpdateTokenValue("access_token", new_access_token);
            info.Properties.UpdateTokenValue("expires_at", expiresAt.ToString("o", CultureInfo.InvariantCulture));
            await HttpContext.SignInAsync("Cookies", info.Principal, info.Properties);
            return tokenResult;
        }
        return null;
    }
