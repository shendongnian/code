    try   
    {
        var temp = SystemIcons.WinLogo.ToBitmap();  //Your icon here
        BitmapImage bitmapImage = new BitmapImage();
        using (MemoryStream memory = new MemoryStream())
        {
           temp.Save(memory, ImageFormat.Png);
           memory.Position = 0;
           bitmapImage.BeginInit();
           bitmapImage.StreamSource = memory;
           bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
           bitmapImage.EndInit();
        }
        this.Icon = bitmapImage;
    }
    catch (Exception ex)
    {
        this.Icon = null;
    }
