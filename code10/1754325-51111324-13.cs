    Bitmap source = (Bitmap)Bitmap.FromFile(@"testimage.png");
    BitmapLocker locker = new BitmapLocker(source);
    locker.Lock();
    Bitmap dest = new Bitmap(source.Width, source.Height, locker.ImagePixelFormat);
    if(source.Palette.Entries.Length > 0)
         dest.Palette = source.Palette;
    BitmapLocker locker2 = new BitmapLocker(dest);
    locker2.Lock();
    for (int h = 0; h < locker.Height; h++)
    {
         for (int w = 0; w < locker.Width; w++)
         {
              locker2.SetPixel(w, h, locker.GetPixel(w, h));
         }
    }
    locker2.Unlock();
    locker.Unlock();
