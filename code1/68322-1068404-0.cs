    BitmapData srcData = bm.LockBits(
                new Rectangle(0, 0, bm.Width, bm.Height), 
                ImageLockMode.ReadOnly, 
                PixelFormat.Format32bppArgb);
    int stride = srcData.Stride;
    IntPtr Scan0 = dstData.Scan0;
    long[] totals = new long[] {0,0,0};
    int width = bm.Width;
    int height = bm.Height;
    unsafe
    {
      byte* p = (byte*) (void*) Scan0;
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          for (int color = 0; color < 3; color++)
          {
            int idx = (y*stride) + x*4 + color;
            totals[color] += p[idx];
          }
        }
      }
    }
    int avgR = totals[0] / (width*height);
    int avgG = totals[1] / (width*height);
    int avgB = totals[2] / (width*height);
