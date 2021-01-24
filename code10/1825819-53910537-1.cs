    public RectangleF TranslateImageSelectedRectangeToPictureBox(PictureBox p, 
        Rectangle imageSelectedRectangle)
    {
        var method = typeof(PictureBox).GetMethod("ImageRectangleFromSizeMode",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var imageRect = (Rectangle)method.Invoke(p, new object[] { p.SizeMode });
        if (p.Image == null)
            return imageSelectedRectangle;
        var cx = (float)p.Image.Width / (float)imageRect.Width;
        var cy = (float)p.Image.Height / (float)imageRect.Height;
        var r2 = new RectangleF(imageSelectedRectangle.X / cx, imageSelectedRectangle.Y / cy,
            imageSelectedRectangle.Width / cx, imageSelectedRectangle.Height / cy);
        r2.Offset(imageRect.X, imageRect.Y);
        return r2;
    }
