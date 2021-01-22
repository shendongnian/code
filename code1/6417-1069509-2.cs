    using(MemoryStream memory = new MemoryStream())
    {
        bitmap.Save(memory, ImageFormat.Png);
        memory.Position = 0;
        BitmapImage bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.StreamSource = memory;
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.EndInit();
    }
