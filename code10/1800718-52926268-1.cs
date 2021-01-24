    public async Task<string> GetRequestAsync(string url, Dictionary<string, string> headers) {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        if (headers != null)
            foreach (var header in headers) {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        var response = await _client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }
