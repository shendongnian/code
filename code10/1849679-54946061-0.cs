    /// <summary>
    /// Loads an image from an URL with the corresponding credentials.
    /// Used instead of picturebox.Load(snapUrl) and picturebox.LoadAsync(snapUrl) because of the errors mentionned in the following sources. 
    /// Sources:
    /// https://stackoverflow.com/questions/54834316/how-to-load-picturebox-image-when-the-connection-to-the-images-site-is-not-priv
    /// https://stackoverflow.com/questions/37763916/asynchronously-load-an-image-from-a-url-to-a-picturebox
    /// </summary>
    /// <param name="snapUrl"></param>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
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
