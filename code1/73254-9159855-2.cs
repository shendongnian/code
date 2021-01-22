    private static void ResizeImagesAsync(string tempuri, Dictionary<string, string> versions)
    {
        Thread t = new Thread (() => ResizeImages(tempuri, versions, null, null));
        t.Start(); 
    }
