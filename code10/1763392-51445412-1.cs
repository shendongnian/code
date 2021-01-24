    public static BitmapImage ConvertBitmapImage(this System.Drawing.Bitmap bitmap)
    {
        var bImg = new BitmapImage();
        using (var ms = new MemoryStream())
        {
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Position = 0; // here, alternatively use ms.Seek(0, SeekOrigin.Begin);
            bImg.BeginInit();
            bImg.CacheOption = BitmapCacheOption.OnLoad; // and here
            bImg.StreamSource = ms;
            bImg.EndInit();
        }
        return bImg;
    }
