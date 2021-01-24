    public async Task Run()
    {
        // This gets populated after calling the web-API and parsing out the result
        List<Stream> files = new List<MemoryStream>{.....};
        var tasks = files.Select(Upload);
        await Task.WhenAll(tasks);
    }
