    private delegate void ResizeImagesDelegate(string tempuri, Dictionary<string, string> versions);
    private static void ResizeImagesAsync(string tempuri, Dictionary<string, string> versions)
    {
        ResizeImagesDelegate worker = new ResizeImagesDelegate(ResizeImages);
        worker.BeginInvoke(tempuri, versions, deletetemp, null, null);
    }
    private static void ResizeImages(string tempuri, Dictionary<string, string> versions)
    {
        //the job, whatever it might be
        foreach (var item in versions)
        {
            var image = ImageBuilder.Current.Build(tempuri, new ResizeSettings(item.Value));
            SaveBlobPng(image, item.Key);
            image.Dispose();
        }
    }
