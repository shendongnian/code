    public static Bitmap Crop(Bitmap bitmap, Rectangle rect)
    {
        // create new bitmap with desired size and same pixel format
        Bitmap croppedBitmap = new Bitmap(rect.Width, rect.Height, bitmap.PixelFormat);
    
        // create Graphics "wrapper" to draw into our new bitmap
        // "using" guarantees a call to gfx.Dispose()
        using (Graphics gfx = Graphics.FromImage(croppedBitmap))
        {
            // draw the wanted part of the original bitmap into the new bitmap
            gfx.DrawImage(bitmap, 0, 0, rect, GraphicsUnit.Pixel);
        }
    
        return croppedBitmap;
    }
