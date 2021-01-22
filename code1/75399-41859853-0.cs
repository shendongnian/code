    private static Color InvertColor(Color c)
    {
      return Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
    }
    // In the following, constants and inplace vars can be parameters in your code
    const byte ALPHA = 192;
    var textColor = Color.Orange;
    var textBrush = new SolidBrush(Color.FromArgb(ALPHA, textColor));
    var textBrushBkg = new SolidBrush(Color.FromArgb(ALPHA, InvertColor(textColor)));
    var font = new Font("Tahoma", 7);
    var info = "whatever you wanna write";
    var r = new Rectangle(10, 10, 10, 10);
    
    // write the text
    using (var g = Graphics.FromImage(yourBitmap))
    {
      g.Clear(Color.Transparent);
      // to avoid bleeding of transparent color, must use SingleBitPerPixelGridFit
      g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
      // Draw background for text
      g.DrawString(info, font, textBrushBkg, r.Left - 1, r.Top - 1);
      g.DrawString(info, font, textBrushBkg, r.Left + 1, r.Top + 1);
      g.DrawString(info, font, textBrushBkg, r.Left + 1, r.Top - 1);
      g.DrawString(info, font, textBrushBkg, r.Left - 1, r.Top + 1);
      // Draw text
      g.DrawString(info, font, textBrush, r.Left, r.Top);
    }
