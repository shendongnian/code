    public async Task<string> GetSignInName (string id)
    {
        RestClient client = new RestClient("https://graph.windows.net/{tenant}/users");
        RestRequest request = new RestRequest($"{id}");
        request.AddParameter("api-version", "1.6");
        request.AddHeader("Authorization", $"Bearer {token}");        
        var response = await client.ExecuteTaskAsync<rootUser>(request);
      
        if (response.ErrorException != null)
        {
            const string message = "Error retrieving response from Windows Graph API.  Check inner details for more info.";
            var exception = new Exception(message, response.ErrorException);
            throw exception;
        }
        return response.Data.Username;
    }
