    public static Color GetRectangleColor(Bitmap sourceBitmap, Int32 x, Int32 y, Int32 width, Int32 height)
    {
        using(Bitmap onePix = new Bitmap(1,1, PixelFormat.Format24bppRgb))
        {
            using (Graphics pg = Graphics.FromImage(onePix)){
                pg.DrawImage(sourceBitmap,
                             new Rectangle(0, 0, 1, 1),
                             new Rectangle(x, y, width, height)),
                             GraphicsUnit.Pixel);
            return onePix.GetPixel(0, 0);
        }
    }
