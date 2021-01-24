    private async Task<Image> GetImageAsync(string snapUrl, string user, string password)
    {
        var tcs = new TaskCompletionSource<Image>();
    
        Action actionGetImage = delegate ()
        {
            var webClient = new WebClient();
            webClient.Credentials = new NetworkCredential(user, password);
            var imgStream = new MemoryStream(webClient.DownloadData(snapUrl));
            tcs.TrySetResult(new System.Drawing.Bitmap(imgStream));
        };
    
        await Task.Factory.StartNew(actionGetImage);
    
        return tcs.Task.Result;
    }
