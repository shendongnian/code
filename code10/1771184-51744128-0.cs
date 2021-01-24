    using (WebClient wc = new WebClient())
    {
        try
        {
            lblProgress.Content = "Downloading page " + counter.ToString();
            await wc.DownloadFileAsync(new Uri(URL), targetPath);
            FileInfo finfo = new FileInfo(targetPath);
            counter++;
        }
        catch
        {
            //...
            return;
        }
    }
