    StringFormat stringFormat = new StringFormat()
    {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center
    };
    
    using (Graphics g = this.CreateGraphics())
    {
        SizeF s = g.MeasureString(text, this.Font);
        float fontScale = Math.Max(s.Width / rect.Width, s.Height / rect.Height);
        using (Font font = new Font(this.Font.FontFamily, this.Font.SizeInPoints / fontScale, GraphicsUnit.Point))
        {
            g.DrawString(text, font, Brushes.Black, rect, stringFormat);
        }
    }
