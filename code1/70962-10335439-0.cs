    System.Drawing.Bitmap bmp;
    Image image;
    ...
    MemoryStream ms = new MemoryStream();
    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    ms.Position = 0;
    BitmapImage bi = new BitmapImage();
    bi.BeginInit();
    bi.StreamSource = ms;
    bi.EndInit();
    image.Source = bi;
