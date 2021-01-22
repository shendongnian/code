        public static Bitmap ToPixelFormat(this Bitmap bmp, PixelFormat format)
        {
            return bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), format);
        }
        
        // usage:
        using (Bitmap oldBmp = new Bitmap("myimage.jpg"))
        using (Bitmap bmp = oldBmp.ToPixelFormat(PixelFormat.Format32bppPArgb))
        {
            // bmp is now in correct format.
        }
