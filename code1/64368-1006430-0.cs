    Bitmap bm = new Bitmap(50, 50);
    using (Font font = new Font(fontName, 10, GraphicsUnit.Point))
    using (Graphics g = Graphics.FromImage(bm))
    {
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        StringFormat stringFormat = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Near
        };
        Rectangle rect = new Rectangle(0, 0, bm.Width, bm.Height);
        // measure how large the text is on the Graphics object with the current font size
        SizeF s = g.MeasureString(text, font);
        // calculate how to scale the font to make the text fit
        float fontScale = Math.Max(s.Width / rect.Width, s.Height / rect.Height);
        using (Font fontForDrawing = new Font(font.FontFamily, font.SizeInPoints / fontScale, GraphicsUnit.Point))
        {
            g.DrawString(text, fontForDrawing, Brushes.Black, rect, stringFormat);
        }
    
    
    }
    
    
