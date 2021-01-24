    private static void GetWebImage(Image image, string path)
    {
        var bFrame = BitmapFrame.Create(
            new Uri(path), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        if (bFrame.IsDownloading)
        {
            bFrame.DownloadCompleted += (e, arg) => AdjustSize(image, bFrame);
        }
        else
        {
            AdjustSize(image, bFrame);
        }
        image.Source = bFrame;
    }
    private static void AdjustSize(Image image, BitmapSource bitmap)
    {
        image.Width = bitmap.PixelWidth;
        image.Height = bitmap.PixelHeight;
        if (image.Height > image.Width)
        {
            if (image.Height > 300)
            {
                image.Width *= 300 / image.Height;
                image.Height = 300;
            }
        }
        else if (image.Width > 400)
        {
            image.Height *= 400 / image.Width;
            image.Width = 400;
        }
        image.Clip = new RectangleGeometry(
            new Rect(0, 0, image.Width, image.Height), 6, 6);
    }
