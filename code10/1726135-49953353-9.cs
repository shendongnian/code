    private Bitmap ASCIIArtBitmap(string text, Font font)
    {
        TextFormatFlags flags = TextFormatFlags.Top | TextFormatFlags.Left | 
                                TextFormatFlags.NoPadding | TextFormatFlags.NoClipping;
        Size bitmapSize = TextRenderer.MeasureText(text, font, Size.Empty, flags);
        using (Bitmap bitmap = new Bitmap(bitmapSize.Width, bitmapSize.Height, PixelFormat.Format24bppRgb))
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            bitmapSize = TextRenderer.MeasureText(graphics, text, font, new Size(bitmap.Width, bitmap.Height), flags);
            TextRenderer.DrawText(graphics, text, font, Point.Empty, Color.Black, Color.White, flags);
            return (Bitmap)bitmap.Clone();
        }
    }
