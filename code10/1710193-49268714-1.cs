    using (WebClient wc = new WebClient())
    {               
        string json = wc.DownloadString(@"JSONlink");
        Result result = JsonConvert.DeserializeObject<Result>(json);
    }
