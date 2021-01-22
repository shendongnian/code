    Rectangle rect = new Rectangle(0, 0, Bitmap.Width, Bitmap.Height);
    System.Drawing.Imaging.BitmapData bmpData = null;
    byte[] bitVaues = null;
    int stride = 0;
    try
    {
        bmpData = Bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, Bitmap.PixelFormat);
        IntPtr ptr = bmpData.Scan0;
        stride = bmpData.Stride;
        int bytes = bmpData.Stride * Bitmap.Height;
        bitVaues = new byte[bytes];
        System.Runtime.InteropServices.Marshal.Copy(ptr, bitVaues, 0, bytes);
    }
    finally
    {
        if (bmpData != null)
            Bitmap.UnlockBits(bmpData);
    }
