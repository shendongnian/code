    System.Windows.Media.Imaging.GifBitmapEncoder gEnc = new GifBitmapEncoder();
            
    foreach (System.Drawing.Bitmap bmpImage in images)
    {
        var bmp = bmpImage.GetHbitmap();
        var src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
            bmp,
            IntPtr.Zero,
            Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions());
        gEnc.Frames.Add(BitmapFrame.Create(src));
        DeleteObject(bmp); // recommended, handle memory leak
    }
    using(FileStream fs = new FileStream(path, FileMode.Create))
    {
        gEnc.Save(fs);
    }
