    Font FindBestFitFont(Graphics g, String text, Font font, 
      Size proposedSize, TextFormatFlags flags)
    { 
      // Compute actual size, shrink if needed
      while (true)
      {
        Size size = TextRenderer.MeasureText(g, text, font, proposedSize, flags);
        // It fits, back out
        if ( size.Height <= proposedSize.Height && 
             size.Width <= proposedSize.Width) { return font; }
        // Try a smaller font (90% of old size)
        Font oldFont = font;
        font = new Font(font.FontFamily, (float)(font.Size * .9)); 
        oldFont.Dispose();
      }
    }
