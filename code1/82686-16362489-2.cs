    [DllImport("kernel32.dll", EntryPoint = "CopyMemory")]
    static extern void CopyMemory(IntPtr Destination, IntPtr Source, uint Length);
    
    public static Bitmap KernellDllCopyBitmap(Bitmap bmp, bool CopyPalette = true)
    {
        Bitmap bmpDest = new Bitmap(bmp.Width, bmp.Height, bmp.PixelFormat);
    
        if (!KernellDllCopyBitmap(bmp, bmpDest, CopyPalette))
            bmpDest = null;
    
        return bmpDest;
    }
    
    
    /// <summary>
            /// Copy bitmap data.
            /// Note: bitmaps must have same size and pixel format.
            /// </summary>
            /// <param name="bmpSrc">Source Bitmap</param>
            /// <param name="bmpDest">Destination Bitmap</param>
            /// <param name="CopyPalette">Must copy Palette</param>
    public static bool KernellDllCopyBitmap(Bitmap bmpSrc, Bitmap bmpDest, bool CopyPalette = false)
    {
        bool copyOk = false;
        copyOk = CheckCompatibility(bmpSrc, bmpDest);
        if (copyOk)
        {
            BitmapData bmpDataSrc;
            BitmapData bmpDataDest;
    
            //Lock Bitmap to get BitmapData
            bmpDataSrc = bmpSrc.LockBits(new Rectangle(0, 0, bmpSrc.Width, bmpSrc.Height), ImageLockMode.ReadOnly, bmpSrc.PixelFormat);
            bmpDataDest = bmpDest.LockBits(new Rectangle(0, 0, bmpDest.Width, bmpDest.Height), ImageLockMode.WriteOnly, bmpDest.PixelFormat);
            int lenght = bmpDataSrc.Stride * bmpDataSrc.Height;
    
            CopyMemory(bmpDataDest.Scan0, bmpDataSrc.Scan0, (uint)lenght);
    
            bmpSrc.UnlockBits(bmpDataSrc);
            bmpDest.UnlockBits(bmpDataDest);
    
            if (CopyPalette && bmpSrc.Palette.Entries.Length > 0)
                bmpDest.Palette = bmpSrc.Palette;
        }
        return copyOk;
    }
        public static bool CheckCompatibility(Bitmap bmp1, Bitmap bmp2)
        {
            return ((bmp1.Width == bmp2.Width) && (bmp1.Height == bmp2.Height) && (bmp1.PixelFormat == bmp2.PixelFormat));
        }
