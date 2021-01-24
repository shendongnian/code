    using (WebClient wc = new WebClient())
    {               
        string json = wc.DownloadString(@"JSONlink");
        var result = JsonConvert.DeserializeObject<List<Result>>(json);
    }
