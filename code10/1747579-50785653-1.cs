    private async void btnURLclick(object sender, RoutedEventArgs e)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        var html = await GetHtmlAsync("http://msdn.microsoft.com");
        Debug.WriteLine($"btn {sw.ElapsedMilliseconds}");
        MessageBox.Show(html.Substring(0, 10));
    }
    public async Task<string> GetHtmlAsync(string url)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        var webClient = new WebClient();
        Debug.WriteLine($"taskA {sw.ElapsedMilliseconds}");
        return await webClient.DownloadStringTaskAsync(url);
    }
