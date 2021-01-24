        public ActionResult SignIn()
        {
            var authContext = new AuthenticationContext("https://login.microsoftonline.com/common");
            string redirectUri = Url.Action("Authorize", "Planner", null, Request.Url.Scheme);
            Uri authUri = authContext.GetAuthorizationRequestURL("https://graph.microsoft.com/", SettingsHelper.ClientId,
    new Uri(redirectUri), UserIdentifier.AnyUser, null);
            // Redirect the browser to the Azure signin page
            return Redirect(authUri.ToString());
        }
        public async Task<ActionResult> Authorize()
        {
            // Get the 'code' parameter from the Azure redirect
            string authCode = Request.Params["code"];
            AuthenticationContext authContext = new AuthenticationContext(SettingsHelper.AzureADAuthority);
            // The same url we specified in the auth code request
            string redirectUri = Url.Action("Authorize", "Planner", null, Request.Url.Scheme);
            // Use client ID and secret to establish app identity
            ClientCredential credential = new ClientCredential(SettingsHelper.ClientId, SettingsHelper.ClientSecret);
            try
            {
                // Get the token
                var authResult = await authContext.AcquireTokenByAuthorizationCodeAsync(
                    authCode, new Uri(redirectUri), credential, SettingsHelper.O365UnifiedResource);
                // Save the token in the session
                Session["access_token"] = authResult.AccessToken;
                return Redirect(Url.Action("Index", "Planner", null, Request.Url.Scheme));
            }
            catch (AdalException ex)
            {
                return Content(string.Format("ERROR retrieving token: {0}", ex.Message));
            }
        } 
