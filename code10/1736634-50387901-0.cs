    public static Color GetRectangleColor(Bitmap sourceBitmap, Int32 x, Int32 y, Int32 width, Int32 height)
    {
        Bitmap onePix = new Bitmap(1,1, PixelFormat.Format32bppArgb);
        Rectangle sourceRect = new Rectangle(x, y, width, height);
        Rectangle onePixRect = new Rectangle(0, 0, 1, 1);
        using (Graphics pg = Graphics.FromImage(onePix))
            pg.DrawImage(sourceBitmap, onePixRect, sourceRect, GraphicsUnit.Pixel);
        Color c = onePix.GetPixel(0, 0);
    }
