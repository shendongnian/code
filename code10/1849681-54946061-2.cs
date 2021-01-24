    private async Task<Image> GetImageAsync(string snapUrl, string user, string password)
    {
        var tcs = new TaskCompletionSource<Image>();
    
        Action actionGetImage = delegate ()
        {
            WebClient wc = new WebClient();
            wc.Credentials = new NetworkCredential(user, password);
            MemoryStream imgStream = new MemoryStream(wc.DownloadData(snapUrl));
            tcs.TrySetResult(new System.Drawing.Bitmap(imgStream));
        };
    
        await Task.Factory.StartNew(actionGetImage);
    
        return tcs.Task.Result;
    }
