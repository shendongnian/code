    public async Task<string> GetHtmlAsync(string url)
    {
        await Task.Delay(1).ConfigureAwait(false);
        var webClient = new WebClient();
        return await webClient.DownloadStringTaskAsync(url).ConfigureAwait(false);
    }
