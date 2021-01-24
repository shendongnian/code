    AuthenticationResult authResult = null;
    string[] scopes = new string[] { "user.read", "mail.read" };
    try 
    {
        authResult = await App
            .PublicClientApp
            .AcquireTokenSilentAsync(
                scopes, 
                App.PublicClientApp.Users.FirstOrDefault());
    } 
    catch (MsalUiRequiredException ex) 
    {
        // MSAL couldn't get the token silently, so go through the interactive process
        authResult = await App
            .PublicClientApp
            .AcquireTokenAsync(scopes);
    }
