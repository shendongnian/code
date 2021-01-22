    private async Task<BitmapImage> LoadImage(string url)
    {
        HttpClient client = new HttpClient();
        try
        {
            BitmapImage img = new BitmapImage();
            img.CacheOption = BitmapCacheOption.OnLoad;
            img.BeginInit();
            img.StreamSource = await client.GetStreamAsync(url);
            img.EndInit();
            return img;
        }
        catch (HttpRequestException)
        {
            // the download failed, log error
            return null;
        }
    }
