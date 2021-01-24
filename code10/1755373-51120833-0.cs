    var pw = width / 2;
    var ph = height / 2;
    var bitmap = img.Source as WriteableBitmap;
    if (bitmap == null || bitmap.PixelWidth != pw || bitmap.PixelHeight != ph)
    {
        bitmap = new WriteableBitmap(pw, ph, 96, 96, pf, null);
        img.Source = bitmap;
    }
    bitmap.WritePixels(new Int32Rect(0, 0, pw, ph), pixelsnew, stride, 0);
