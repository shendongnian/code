        public static Bitmap ToPixelFormat(this Image image, PixelFormat format)
        {
            if (image.PixelFormat == format)
                return new Bitmap(image);
            Bitmap bmp = new Bitmap(image.Width, image.Height, format);
            bmp = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), format);
            return bmp;
        }
