    var result = string.Empty;
    using (var webClient = new System.Net.WebClient())
    {
        result = webClient.DownloadString("http://some.url");
    }
