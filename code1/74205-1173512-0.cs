    private Bitmap convertTo1bpp(Bitmap img)
    {
        BitmapData bmdo = img.LockBits(New Rectangle(0, 0, img.Width, img.Height),
                                       ImageLockMode.ReadOnly, 
                                       img.PixelFormat);
        // and the new 1bpp bitmap
        Bitmap bm = new Bitmap(img.Width, img.Height, PixelFormat.Format1bppIndexed);
        BitmapData bmdn = bm.LockBits(New Rectangle(0, 0, bm.Width, bm.Height),
                                      ImageLockMode.ReadWrite, 
                                      PixelFormat.Format1bppIndexed);
        // scan through the pixels Y by X
        for(int y = 0; y < img.Height; y++)
        {
            for(int x = 0; x < img.Width; x++)
            {
                // generate the address of the colour pixel
                int index = y * bmdo.Stride + x * 4;
		
                // check its brightness
                if(Color.FromArgb(Marshal.ReadByte(bmdo.Scan0, index + 2), 
                                  Marshal.ReadByte(bmdo.Scan0, index + 1), 
                                  Marshal.ReadByte(bmdo.Scan0, index)).GetBrightness() > 0.5F)
                {
                    setIndexedPixel(x, y, bmdn, True); // set it if its bright.
                }
             }
        }
        // tidy up
        bm.UnlockBits(bmdn);
        img.UnlockBits(bmdo);
    }
  
    private void setIndexedPixel(int x, int y, BitmapData bmd, bool pixel)
    {
        int index = y * bmd.Stride + (x >> 3);
        byte p = Marshal.ReadByte(bmd.Scan0, index);
        byte mask = 0x80 >> (x & 0x7);
        if(pixel)
        {
            p |= mask;
        }
        else
        {
            p &= (byte)(mask ^ 0xFF);
        }
        Marshal.WriteByte(bmd.Scan0, index, p);
    }
