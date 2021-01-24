    [Command("printFile")]
    public async Task PrintFile()
    {
        var attachments = Context.Message.Attachments;
    
        // Create a new WebClient instance.
        WebClient myWebClient = new WebClient();
    
        string file = attachments.ElementAt(0).Filename;
        string url = attachments.ElementAt(0).Url;
    
        // Download the resource and load the bytes into a buffer.
        byte[] buffer = myWebClient.DownloadData(url);
    
        // Encode the buffer into UTF-8
        string download = Encoding.UTF8.GetString(buffer);
    
        Console.WriteLine("Download successful.");
    
        // Place the contents as a message because the method said it should.
        await ReplyAsync("Received attachment!\n\n" + download);
    }
