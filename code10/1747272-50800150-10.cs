    public static async Task<string> Run(string url, string token)
    {
        
        var httpClient = new HttpClient();
        HttpResponseMessage response;
        try {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        catch (Exception ex) {
            return ex.ToString();
        }
    }
