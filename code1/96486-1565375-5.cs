    using (Graphics g = this.CreateGraphics())
    {
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        SizeF size = g.MeasureString("a", this.Font, new PointF(0, 0), 
            StringFormat.GenericTypographic);
        float maxWidth = 50; // or whatever
        int numberOfCharacters = (int)(maxWidth / size.Width);
    }
