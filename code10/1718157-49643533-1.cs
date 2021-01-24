        ///////////////////////////////////
        // Added line here
        ///////////////////////////////////
        // Add a custom claim to the user's ObjectId ('oid' in the token); Access it with this code: ((System.Security.Claims.ClaimsIdentity)User.Identity).FindFirst("ObjectId").Value
        notification.AuthenticationTicket.Identity.AddClaim(new System.Security.Claims.Claim("ObjectId", signedInUserID));
        try
        {
            AuthenticationResult result = await cca.AcquireTokenByAuthorizationCodeAsync(code, Scopes);
        }
        catch (Exception ex)
        {
            MyLogger.LogTrace("Failed to retrieve AuthenticationResult Token for user " + signedInUserID, MyLogger.LogLevel.Critical);
                return;
        }
    }
