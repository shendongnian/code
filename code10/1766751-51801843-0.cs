    Bitmap colorBitmap(Color forGroundColor, Color backGroundColor, Bitmap bmpGrayScale)
    {
      Size size = bmpGrayScale.Size;
      Bitmap applyForgroundColor= new Bitmap(size.Width, size.Height);
      Rectangle rect1 = new Rectangle(Point.Empty, bmpGrayScale.Size);
      using (Graphics G1 = Graphics.FromImage(applyForgroundColor) )
      {
        G1.Clear(forGroundColor);
        G1.DrawImageUnscaledAndClipped(applyForgroundColor, rect1);
      }
      for (int y = 0; y < size.Height; y++)
        for (int x = 0; x < size.Width; x++)
        {
          Color c1 = applyForgroundColor.GetPixel(x, y);
          Color c2 = bmpGrayScale.GetPixel(x, y);
          applyForgroundColor.SetPixel(x, y, Color.FromArgb((int)(255 * c2.GetBrightness()), c1 ) );
        }
	
      Bitmap applyBackgroundColor= new Bitmap(size.Width, size.Height);
      Rectangle rect2 = new Rectangle(Point.Empty, bmpGrayScale.Size);
      using (Graphics G2 = Graphics.FromImage(applyBackgroundColor) )
      {
        G2.Clear(backGroundColor);
        G2.DrawImageUnscaledAndClipped(applyForgroundColor, rect2);
      }
      return applyBackgroundColor;
    }
