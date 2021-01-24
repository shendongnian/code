    public async Task<string> Groups()
    {
        string[] scopes = { "https://analysis.windows.net/powerbi/api/Dataset.Read.All"};
        try
        {
            string accessToken = await _tokenAcquisition.GetAccessTokenOnBehalfOfUser(HttpContext, scopes);
            var tokenCredentials = new TokenCredentials(accessToken, "Bearer");
            using (var client = new PowerBIClient(new Uri(_powerBiConfig.ApiUrl), tokenCredentials))
            {
                return JsonConvert.SerializeObject(client.Groups.GetGroups().Value, Formatting.Indented);
            }
        }
        catch (Exception exc)
        {
            return string.Empty;
        }
    }
