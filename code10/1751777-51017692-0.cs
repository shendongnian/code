    Notifications = new OpenIdConnectAuthenticationNotifications
    {
        AuthorizationCodeReceived = async n =>
        {
            var tokenClient = new TokenClient(identityServerUrl + "/connect/token", clientId, secret);
            var tokenResponse = await tokenClient.RequestAuthorizationCodeAsync(n.Code, n.RedirectUri);
            HttpContext.Current.Session[HttpUserContext.ACCESS_TOKEN] = tokenResponse.AccessToken;
        }
    }
