    public static void FillPattern(Graphics g, Image image, Rectangle rect)
    {
        Rectangle imageRect;
        Rectangle drawRect;
        for (int x = rect.X; x < rect.Right; x += image.Width)
        {
            for (int y = rect.Y; y < rect.Bottom; y += image.Height)
            {
                drawRect = new Rectangle(x, y, Math.Min(image.Width, rect.Right - x),
                               Math.Min(image.Height, rect.Bottom - y));
                imageRect = new Rectangle(0, 0, drawRect.Width, drawRect.Height);
                g.DrawImage(image, drawRect, imageRect, GraphicsUnit.Pixel);
            }
        }
    }
