    private BitmapSource CreateThumbnail(string path)
    {
        BitmapImage bmpImage = new BitmapImage();
        bmpImage.BeginInit();
        bmpImage.UriSource = new Uri(path);
        bmpImage.DecodePixelWidth = 120;
        // bmpImage.DecodePixelHeight = 120; // alternatively, but not both
        bmpImage.EndInit();
        return bmpImage;
    }
