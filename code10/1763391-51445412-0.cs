    public static BitmapImage ConvertBitmapImage(this System.Drawing.Bitmap bitmap)
    {
        using (var ms = new MemoryStream())
        {
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Position = 0; // here
            var bImg = new BitmapImage();
            bImg.BeginInit();
            bImg.CacheOption = BitmapCacheOption.OnLoad; // and here
            bImg.StreamSource = ms;
            bImg.EndInit();
            return bImg;
        }
    }
