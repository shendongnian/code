    static Lazy<HttpClient> http = new Lazy<HttpClient>(() => {
        //Handle TLS protocols
        System.Net.ServicePointManager.SecurityProtocol =
            System.Net.SecurityProtocolType.Tls
            | System.Net.SecurityProtocolType.Tls11
            | System.Net.SecurityProtocolType.Tls12;
        var handler = new HttpClientHandler() {
            UseDefaultCredentials = true
        };
        var client = new HttpClient(handler);
        return client;
    });
    protected static async Task<UrlResponse> GetUrl(string baseUrl) {
        var client = http.Value;
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
