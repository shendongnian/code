    private async Task ReadImages (string HTMLtag)
    {
        string section = HTMLtag.Split(':')[0];
        string tag = HTMLtag.Split(':')[1];
    
        List<string> UsedAdresses = new List<string>();
        var webClient = new WebClient();
        string page = await webClient.DownloadStringAsync(Link);
    
        //...
    }
