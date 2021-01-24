    void FillIndexedRectangle(Bitmap bmp8bpp, Rectangle rect, Color col, int index)
    {
        var pal = bmp8bpp.Palette;
        int idx = -1;
        if (index >= 0) idx = index;
        else
        {
            if (pal.Entries.Where(x => x.ToArgb() == col.ToArgb()).Any())
                idx = pal.Entries.ToList().FindIndex(x => x.ToArgb() == col.ToArgb());
            if (idx < 0) idx = pal.Entries.Length - 1;
        }
            
        pal.Entries[idx] = col;
        bmp8bpp.Palette = pal;
        var bitmapData = 
            bmp8bpp.LockBits(new Rectangle(Point.Empty, bmp8bpp.Size),
                             ImageLockMode.ReadWrite, bmp8bpp.PixelFormat);
        byte[] buffer=new byte[bmp8bpp.Width*bmp8bpp.Height];
        Marshal.Copy(bitmapData.Scan0, buffer,0, buffer.Length);
        for (int y = rect.Y; y < rect.Bottom; y++)
        for (int x = rect.X; x < rect.Right; x++)
        {
                buffer[x + y * bmp8bpp.Width] = (byte)idx;
        }
        Marshal.Copy(buffer, 0, bitmapData.Scan0,buffer.Length);
        bmp8bpp.UnlockBits(bitmapData);
    }
