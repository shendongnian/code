    var image = new BitmapImage(new Uri(link));
    if (image.IsDownloading)
    {
        image.DownloadCompleted += (s, e) => ShowImage(image);
    }
    else
    {
        ShowImage(image);
    }
