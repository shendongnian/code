    int w = 48;
    int h = 32;
    int cols = w / 8;
    Bitmap bmp = new Bitmap(w, h,  PixelFormat.Format1bppIndexed);
    BitmapData bmpData = bmp.LockBits(
                            new Rectangle(0, 0, bmp.Width, bmp.Height),
                            ImageLockMode.WriteOnly, bmp.PixelFormat);
    for (int i = 0; i < h; i++)
    {
        Marshal.Copy(blob, i * cols, bmpData.Scan0, cols);
    }
    bmp.UnlockBits(bmpData);
    return bmp;
