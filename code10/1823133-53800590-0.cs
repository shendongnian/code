    public RectangleF GetRectangeOnImage(PictureBox p, Rectangle selectionRect)
    {
        var method = typeof(PictureBox).GetMethod("ImageRectangleFromSizeMode",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var imageRect = (Rectangle)method.Invoke(p, new object[] { p.SizeMode });
        if (p.Image == null)
            return selectionRect;
        var c = (float)p.Image.Width / (float)imageRect.Width;
        var r2 = Rectangle.Intersect(imageRect, selectionRect);
        r2.Offset(-imageRect.X, -imageRect.Y);
        return new RectangleF(r2.X * c, r2.Y * c, r2.Width * c, r2.Height * c);
    }
