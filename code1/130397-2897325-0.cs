    Bitmap GetBitmap(BitmapSource source) {
      Bitmap bmp = new Bitmap(
        source.PixelWidth,
        source.PixelHeight,
        PixelFormat.Format32bppPArgb);
      BitmapData data = bmp.LockBits(
        new Rectangle(Point.Empty, bmp.Size),
        ImageLockMode.WriteOnly,
        PixelFormat.Format32bppPArgb);
      source.CopyPixels(
        Int32Rect.Empty,
        data.Scan0,
        data.Height * data.Stride,
        data.Stride);
      bmp.UnlockBits(data);
      return bmp;
    }
