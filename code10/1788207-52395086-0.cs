    private static async Task<string> GetTokenAsync(PublicClientApplication clientApp)
        {
            AuthenticationResult result = null;
            try
            {
                string[] scopes = { "User.Read", "Mail.ReadWrite", "offline_access" };
                // Get the token from the cache.
                result = await app.AcquireTokenSilentAsync(scopes, clientApp.Users.FirstOrDefault());
                return result.AccessToken;
            }
            catch (MsalUiRequiredException ex)
            {
                // A MsalUiRequiredException happened on AcquireTokenSilentAsync. 
                // This indicates you need to call AcquireTokenAsync to acquire a token
                System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");
                try
                {
                    // Dialog opens for user.
                    result = await app.AcquireTokenAsync(scopes);
                    return result.AccessToken;
                }
                catch (MsalException msalex)
                {
                    ResultText.Text = $"Error Acquiring Token:{System.Environment.NewLine}{msalex}";
                }
            }
            catch (Exception ex)
            {
                ResultText.Text = $"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}";
                return;
            }
        }
