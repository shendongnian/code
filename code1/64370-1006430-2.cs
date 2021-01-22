    Bitmap bm = new Bitmap(20, 20);
    using (Font font = new Font(fontName, 6, GraphicsUnit.Point))
    using (Graphics g = Graphics.FromImage(bm))
    {
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        StringFormat stringFormat = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Near
        };
        Rectangle rect = new Rectangle(0, 0, bm.Width, bm.Height);
        g.DrawString(text, font, Brushes.Black, rect, stringFormat);
    }
    
