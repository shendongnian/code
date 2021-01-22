    IntPtr pval = IntPtr.Zero;
    System.Drawing.Imaging.BitmapData bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
    try
    {
        pval=bd.Scan0;
        
        ...
    }
    finally
    {
        bmp.UnlockBits(bd);
    }
