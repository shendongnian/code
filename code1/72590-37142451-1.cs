    private static async Task DownloadLinkAsync(Uri documentLinkUrl)
    {
        var cookieString = GetGlobalCookies(documentLinkUrl.AbsoluteUri);
        var cookieContainer = new CookieContainer();
        using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
        using (var client = new HttpClient(handler) { BaseAddress = documentLinkUrl })
        {
            cookieContainer.SetCookies(this.documentLinkUrl, cookieString);
            var response = await client.GetAsync(documentLinkUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseAsString = await response.Content.ReadAsStreamAsync();
                // Response can be saved from Stream
            }
        }
    }
