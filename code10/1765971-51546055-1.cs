    OutfitImage = BitmapToBitmapSource(nb);
    ...
    public static BitmapSource BitmapToBitmapSource(System.Drawing.Bitmap bitmap)
    {
        var bitmapImage = new BitmapImage();
        using (var stream = new MemoryStream())
        {
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Position = 0;
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
        }
        return bitmapImage;
    }
