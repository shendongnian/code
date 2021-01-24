    public static BitmapSource Base64ToImage(string base64)
    {
        using (var stream = new MemoryStream(Convert.FromBase64String(base64)))
        {
            return BitmapFrame.Create(
                stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }
    }
