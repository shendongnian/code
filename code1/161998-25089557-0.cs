    static Bitmap TextToBitmap(string text, Font font, Color foregroundColor)
    {
      SizeF textSize;
      using ( var g = Graphics.FromHwndInternal(IntPtr.Zero) )
        textSize = g.MeasureString(text, font);
      var image = new Bitmap((int)Math.Ceiling(textSize.Width), (int)Math.Ceiling(textSize.Height));
      var brush = new SolidBrush(foregroundColor);
      using ( var g = Graphics.FromImage(image) )
      {
        g.Clear(Color.Magenta);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.DrawString(text, font, brush, 0, 0);
        g.Flush();
      }
      image.MakeTransparent(Color.Magenta);
      // The image now has a transparent background, but around each letter are antialiasing artifacts still keyed to magenta.  We need to remove those.
      RemoveChroma(image, foregroundColor, Color.Magenta);
      return image;
    }
    static unsafe void RemoveChroma(Bitmap image, Color foregroundColor, Color chroma)
    {
      if (image == null) throw new ArgumentNullException("image");
      BitmapData data = null;
      try
      {
        data = image.LockBits(new Rectangle(Point.Empty, image.Size), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        for ( int y = data.Height - 1; y >= 0; --y )
        {
          int* row = (int*)(data.Scan0 + (y * data.Stride));
          for ( int x = data.Width - 1; x >= 0; --x )
          {
            Color pixel = Color.FromArgb(row[x]);
            if ( (pixel != foregroundColor) &&
                 ((pixel.B >= foregroundColor.B) && (pixel.B <= chroma.B)) &&
                 ((pixel.G >= foregroundColor.G) && (pixel.G <= chroma.G)) &&
                 ((pixel.R >= foregroundColor.R) && (pixel.R <= chroma.R)) )
            {
              row[x] = Color.FromArgb(
                255 - ((int)
                  ((Math.Abs(pixel.B - foregroundColor.B) +
                    Math.Abs(pixel.G - foregroundColor.G) +
                    Math.Abs(pixel.R - foregroundColor.R)) / 3)),
                foregroundColor).ToArgb();
            }
          }
        }
      }
      finally
      {
        if (data != null) image.UnlockBits(data);
      }
    }
