    private Bitmap ASCIIArtBitmapGdiPlus(string text, Font font)
    {
        using (Bitmap modelbitmap = new Bitmap(10, 10, PixelFormat.Format24bppRgb))
        using (Graphics modelgraphics = Graphics.FromImage(modelbitmap))
        {
            modelgraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            SizeF bitmapSize = modelgraphics.MeasureString(text, font, Point.Empty, StringFormat.GenericTypographic);
            using (Bitmap bitmap = new Bitmap((int)bitmapSize.Width, (int)bitmapSize.Height, PixelFormat.Format24bppRgb))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                graphics.TextContrast = 1;
                graphics.DrawString(text, font, Brushes.Black, PointF.Empty, StringFormat.GenericTypographic);
                return (Bitmap)bitmap.Clone();
            }
        }
    }
