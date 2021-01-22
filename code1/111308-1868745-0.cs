    public static bool Invert(Bitmap b)
    {
    
    BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), 
                                   ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); 
    int stride = bmData.Stride; 
    System.IntPtr Scan0 = bmData.Scan0; 
    unsafe 
    { 
        byte * p = (byte *)(void *)Scan0;
        int nOffset = stride - b.Width*3; 
        int nWidth = b.Width * 3;
        for(int y=0;y < b.Height;++y)
        {
            for(int x=0; x < nWidth; ++x )
            {
                p[0] = (byte)(255-p[0]);
                ++p;
            }
            p += nOffset;
        }
    }
    b.UnlockBits(bmData);
    return true;
}
