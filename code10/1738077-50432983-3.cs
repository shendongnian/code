    int w = 48;
    int h = 32;
    int unpadded = w / 8;   // unpadded byte length of one line in your data
    Bitmap bmp = new Bitmap(w, h,  PixelFormat.Format1bppIndexed);
    BitmapData bmpData = bmp.LockBits(
                            new Rectangle(0, 0, bmp.Width, bmp.Height),
                            ImageLockMode.WriteOnly, bmp.PixelFormat);
    int stride = 8 // padded length of scanline
    for (int i = 0; i < h; i++)
    {
        Marshal.Copy(blob, i * unpadded , bmpData.Scan0 + i * stride, unpadded );  
    }
    bmp.UnlockBits(bmpData);
    return bmp;
