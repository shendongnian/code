    public string GetDocumentInfo(string path)
    {
        var web = new HtmlWeb();
        var doc = web.Load(path);
        // ... etc ... etc
    }
