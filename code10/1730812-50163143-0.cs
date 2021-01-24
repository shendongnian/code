    private async void button1_Click(object sender, EventArgs e)
    {
                
        var downloader = new TransformBlock<string, WebResponse>(
                url => Download(url),
                new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 200 }
            );
    
        var buffer = new BufferBlock<WebResponse>();
        downloader.LinkTo(buffer);
    
        var urls = new List<string>();
        for (int i = 0; i < 100000; i++)
        {
            urls.Add($"http://example{i}.com");
        }
    
        foreach (var url in urls)
            downloader.Post(url);
        //or await downloader.SendAsync(url);
    
        downloader.Complete();
        await downloader.Completion;
    
        IList<WebResponse> responses;
        if (buffer.TryReceiveAll(out responses))
        {
            //process responses        
        }
    }
    
    private WebResponse Download(string url)
    {
        WebResponse resp = null;
        try
        {
            var req = WebRequest.Create(url);
            resp = req.GetResponse();
        }
        catch (Exception)
        {
    
        }
        return resp;
    }
    }
