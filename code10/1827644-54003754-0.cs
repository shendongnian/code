    public static async Task<string> UpdateFileData()
    {
        var (authResult, message) = await Authentication.AquireTokenAsync();
    
        string updateurl = MainPage.rooturl + "lists/edd49389-7edb-41db-80bd-c8493234eafa/items/" + fileID + "/";
        var httpClient = new HttpClient();
        HttpResponseMessage response;
        try
        {
            var root = new
            {
                fields = new Dictionary<string, string>
                {
                    { "IBX", App.IBX },  //column to update
                    { "Year", App.Year}, //column to update
                    { "Month", App.Month} //column to update
                }
            };
    
            var s = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            var content = JsonConvert.SerializeObject(root, s);
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), updateurl);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            request.Content = new StringContent(content, System.Text.Encoding.UTF8, "application/json;odata=verbose");
            response = await httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }
