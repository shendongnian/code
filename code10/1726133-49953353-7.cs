    private Bitmap ASCIIArtBitmapGdiPlusPath(string text, Font font)
    {
        GraphicsPath GPath = new GraphicsPath(FillMode.Alternate);
        GPath.AddString(text, font.FontFamily, (int)font.Style, 4, Point.Empty, StringFormat.GenericTypographic);
        Rectangle GPathArea = Rectangle.Round(GPath.GetBounds());
        using (Bitmap bitmap = new Bitmap(GPathArea.Width, GPathArea.Height))
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            graphics.Clear(Color.White);
            graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.FillPath(Brushes.Black, GPath);
            return (Bitmap)bitmap.Clone();
        }
    }
