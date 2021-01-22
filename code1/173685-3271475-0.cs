      // Load the bitmap
      Bitmap originalBitmap = Bitmap.FromFile("d:\\temp\\test.bmp") as Bitmap;
      // Find the min/max non-white/transparent pixels
      Point min = new Point(int.MaxValue, int.MaxValue);
      Point max = new Point(int.MinValue, int.MinValue);
      for (int x = 0; x < originalBitmap.Width; ++x)
      {
        for (int y = 0; y < originalBitmap.Height; ++y)
        {
          Color pixelColor = originalBitmap.GetPixel(x, y);
          if (!(pixelColor.R == 255 && pixelColor.G == 255 && pixelColor.B == 255)
            || pixelColor.A < 255)
          {
            if (x < min.X) min.X = x;
            if (y < min.Y) min.Y = y;
            if (x > max.X) max.X = x;
            if (y > max.Y) max.Y = y;
          }
        }
      }
      // Create a new bitmap from the crop rectangle
      Rectangle cropRectangle = new Rectangle(min.X, min.Y, max.X - min.X, max.Y - min.Y);
      Bitmap newBitmap = new Bitmap(cropRectangle.Width, cropRectangle.Height);
      using (Graphics g = Graphics.FromImage(newBitmap))
      {
        g.DrawImage(originalBitmap, 0, 0, cropRectangle, GraphicsUnit.Pixel);
      }
