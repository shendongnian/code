    private static void GetWebImage(Image image, string path)
    {
        var bFrame = BitmapFrame.Create(
            new Uri(path), BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        if (bFrame.IsDownloading)
        {
            bFrame.DownloadCompleted += (e, arg) =>
            {
                image.Width = bFrame.PixelWidth;
                image.Height = bFrame.PixelHeight;
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
            };
        }
        image.Source = bFrame;
    }
