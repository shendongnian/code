    public static async Task<string> AddGroupMember(string accessToken, string groupId, string memberId)
    {
        var status = string.Empty;
        try
        {
            string endpoint = "https://graph.microsoft.com/v1.0/groups/" + groupId + "/members/$ref";
            string queryParameter = "";
            // pass body data 
            var keyOdataId = "@odata.id";
            var valueODataId = "https://graph.microsoft.com/v1.0/directoryObjects/" + memberId;
            var values = new List<KeyValuePair<string, string>>
    {
        new KeyValuePair<string, string>(keyOdataId, valueODataId)
    };
            var jsonData = $@"{{ ""{keyOdataId}"": ""{valueODataId}"" }}";
            var body = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint + queryParameter))
                {
                    request.Content = body;
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    using (var response = await client.SendAsync(request))
                    {
                        if (response.StatusCode == HttpStatusCode.NoContent)
                            status = "Member added to Group";
                        else
                            status = $"Unable to add Member to Group: {response.StatusCode}";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            status = $"Error adding Member to Group: {ex.Message}";
        }
        return status;
    }
