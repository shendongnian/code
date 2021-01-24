    private static async Task<string> GetAPI(string url)
        {
        // TODO: Use a shared instance of HttpClient
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-api-key", "SomeSecretApiKey");
    
            var jsonString = await client.GetStringAsync(url).ConfigureAwait(false);
            return jsonString;
        }
    }
