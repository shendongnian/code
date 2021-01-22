    public BitmapSource GetCurrPicture()
    {
        var bitmapImage = new BitmapImage();
        using (Stream stream = new MemoryStream((byte[])FrameList[currFrame-1]))
        {
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
            bitmapImage.Freeze();
            return bitmapImage;
        }
    }
