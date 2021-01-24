       // The OpenID Connect middleware sends this event when it gets the authorization code.   
        public override async Task AuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
        {
            string authorizationCode = context.ProtocolMessage.Code;
            string authority = "https://login.microsoftonline.com/" + tenantID
            string resourceID = "https://tailspin.onmicrosoft.com/surveys.webapi" // App ID URI
            ClientCredential credential = new ClientCredential(clientId, clientSecret);
    
            AuthenticationContext authContext = new AuthenticationContext(authority, tokenCache);
            AuthenticationResult authResult = await authContext.AcquireTokenByAuthorizationCodeAsync(
            authorizationCode, new Uri(redirectUri), credential, resourceID);
    
            // If successful, the token is in authResult.AccessToken
        }
