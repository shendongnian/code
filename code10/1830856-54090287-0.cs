    protected static async Task<UrlResponse> GetUrl(string baseUrl) {
        HttpClientHandler handler = new HttpClientHandler();
        handler.UseDefaultCredentials = true;
        var client = new HttpClient(handler);
        var response = await client.GetAsync(baseUrl); //Remove .Result and just await
        if (response.IsSuccessStatusCode) {
            HttpResponseMessage response1 = response;
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UrlResponse>(resp);
            return result;
        }
        return null;
    }
