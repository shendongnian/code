    private static void GetWebImage(Image image, string path)
    {
        var bitmap = new BitmapImage(new Uri(path));
        if (bitmap.IsDownloading)
        {
            bitmap.DownloadCompleted += (s, e) => AdjustSize(image, bitmap);
        }
        else
        {
            AdjustSize(image, bitmap);
        }
        image.Source = bitmap;
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
