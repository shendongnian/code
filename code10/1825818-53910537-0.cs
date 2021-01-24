    public RectangleF TranslatePictureBoxSelectedRectangeToImage(PictureBox p, 
        Rectangle pictureBoxSelectedRectangle)
    {
        var method = typeof(PictureBox).GetMethod("ImageRectangleFromSizeMode",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var imageRect = (Rectangle)method.Invoke(p, new object[] { p.SizeMode });
        if (p.Image == null)
            return pictureBoxSelectedRectangle;
        var cx = (float)p.Image.Width / (float)imageRect.Width;
        var cy = (float)p.Image.Height / (float)imageRect.Height;
        var r2 = pictureBoxSelectedRectangle;
        r2.Offset(-imageRect.X, -imageRect.Y);
        return new RectangleF(r2.X * cx, r2.Y * cy, r2.Width * cx, r2.Height * cy);
    }
