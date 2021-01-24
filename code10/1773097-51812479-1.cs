    private async void AorBButton_Click(object sender, RoutedEventArgs e)
    {
        var (authResult, message) = await AquireToken();
        ResultText.Text = message;
        if (authResult != null) {
            // performs one thing or the other thing
        }
    }
    private async Task<(AuthenticationResult authResult, string message)> AquireToken()
    {
        AuthenticationResult authResult = null;
        string message = String.Empty;
        try {
            authResult = await App.PublicClientApp.AcquireTokenSilentAsync(scopes, App.PublicClientApp.Users.FirstOrDefault());
        } catch (MsalUiRequiredException ex) {
            // A MsalUiRequiredException happened on AcquireTokenSilentAsync. This indicates you need to call AcquireTokenAsync to acquire a token
            System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");
            try {
                authResult = await App.PublicClientApp.AcquireTokenAsync(scopes);
            } catch (MsalException msalex) {
                message = $"Error Acquiring Token:{System.Environment.NewLine}{msalex}";
            }
        } catch (Exception ex) {
            message = $"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}";
        }
        return (authResult, message);
    }
