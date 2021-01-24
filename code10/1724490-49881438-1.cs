    // Convert a byte array into a BitmapImage.
    private static BitmapImage BytesToImage(byte[] bytes)
    {
        var bm = new BitmapImage();
        using (MemoryStream stream = new MemoryStream(bytes))
        {
            stream.Position = 0;
            bm.BeginInit();
            bm.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            bm.CacheOption = BitmapCacheOption.OnLoad;
            bm.UriSource = null;
            bm.StreamSource = stream;
            bm.EndInit();
        }
        return bm;
    }
