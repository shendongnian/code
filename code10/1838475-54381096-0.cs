    public static string GetAccessToken()
    {
        var oauth2Client = new OAuth2Client(CLIENTID_FROM_STEP_2, 
                CLIENT_SECRET_FROM_STEP_2,
                // Redirect not used but matches entry for app
                "https://developer.intuit.com/v2/OAuth2Playground/RedirectUrl",
                "production"); // environment is “sandbox” or “production”
        var previousRefreshToken = ReadRefreshTokenFromWhereItIsStored();
        var tokenResp = oauth2Client.RefreshTokenAsync(previousRefreshToken );
        tokenResp.Wait();
        var data = tokenResp.Result;
    
        if ( !String.IsNullOrEmpty(data.Error) || String.IsNullOrEmpty(data.RefreshToken) || 
              String.IsNullOrEmpty(data.AccessToken))
        {
            throw new Exception("Refresh token failed - " + data.Error);
        }
    
        // If we've got a new refresh_token store it in the file
        if (previousRefreshToken != data.RefreshToken)
        {
            Console.WriteLine("Writing new refresh token : " + data.RefreshToken);
            WriteNewRefreshTokenToWhereItIsStored(data.RefreshToken)
        }
        return data.AccessToken;
    }
