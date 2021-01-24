    using (var httpClient = new HttpClient())
    {
        var bytesToSkip = 100_000;
        var httpRequestMessage = new HttpRequestMessage
        {
            RequestUri = new Uri("file to download"),
            Method = HttpMethod.Get,
            Headers = { Range = new RangeHeaderValue(bytesToSkip, null)}
        };
        var response = await httpClient.SendAsync(httpRequestMessage);
        var content = await response.Content.ReadAsByteArrayAsync();
    }
