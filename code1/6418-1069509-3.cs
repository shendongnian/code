    using(MemoryStream memory = new MemoryStream())
    {
        bitmap.Save(memory, ImageFormat.Png);
        memory.Position = 0;
        BitmapImage bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = memory;
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.EndInit();
    }
