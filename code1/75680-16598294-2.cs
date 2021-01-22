    System.Windows.Media.Imaging.GifBitmapEncoder gEnc = new GifBitmapEncoder();
            
    foreach (System.Drawing.Bitmap bmpImage in images)
    {
        var src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
            bmpImage.GetHbitmap(),
            IntPtr.Zero,
            Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions());
        gEnc.Frames.Add(BitmapFrame.Create(src));
    }
    gEnc.Save(new FileStream(path, FileMode.Create));
