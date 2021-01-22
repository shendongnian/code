    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    ...
    public static Bitmap BitmapTo1Bpp(Bitmap img) {
      int w = img.Width;
      int h = img.Height;
      Bitmap bmp = new Bitmap(w, h, PixelFormat.Format1bppIndexed);
      BitmapData data = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);
      byte[] scan = new byte[(w + 7) / 8];
      for (int y = 0; y < h; y++) {
        for (int x = 0; x < w; x++) {
          if (x % 8 == 0) scan[x / 8] = 0;
          Color c = img.GetPixel(x, y);
          if (c.GetBrightness() >= 0.5) scan[x / 8] |= (byte)(0x80 >> (x % 8));
        }
        Marshal.Copy(scan, 0, (IntPtr)((long)data.Scan0 + data.Stride * y), scan.Length);
      }
      bmp.UnlockBits(data);
      return bmp;
    }
