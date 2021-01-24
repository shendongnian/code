    private async void GetMsaTokenAsync(WebAccountProviderCommand command)
    {
        WebTokenRequest request = new WebTokenRequest(command.WebAccountProvider, "wl.basic");
        WebTokenRequestResult result = await WebAuthenticationCoreManager.RequestTokenAsync(request);
        if (result.ResponseStatus == WebTokenRequestStatus.Success)
        {
            // TODO
        }
        if (result.ResponseStatus== WebTokenRequestStatus.UserCancel)
        {
            // User click the "X"
        }
    }
