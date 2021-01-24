    async Task Main()
    {
        //Normal speed
        var feed = await GetFeed("https://taeguk.co.uk/feed/");
        Console.WriteLine(feed);
    
        //Too Slow = null
        feed = await GetFeed("http://www.deelay.me/2000/https://taeguk.co.uk/feed/");
        Console.WriteLine(feed);
    }
    
    async Task<SyndicationFeed> GetFeed(String url)
    {
        var task = Task.Factory.StartNew(() =>
                {
                    XmlReader reader = XmlReader.Create(url);
                    return SyndicationFeed.Load(reader);
                });
    
        int timeout = 1000;
        if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
        {
            return await task;
        }
        else
        {
            return null;
        }
    }
