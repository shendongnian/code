    private async Task Execute()
    {
        string tags = ConfigurationManager.AppSettings["HTMLTags"];
    
        var cursor = Mouse.OverrideCursor;
        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
        List<Task> tasks = new List<Task>();
        foreach (string tag in tags.Split(';'))
        {
             tasks.Add(ReadImagesAsync(tag));
             //tasks.Add(Task.Run(() => ReadImages(tag)));
        }
    
        await Task.WhenAll(tasks.ToArray());
        Mouse.OverrideCursor = cursor;
    }
