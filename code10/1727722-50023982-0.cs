        public static Bitmap ResizeImage(Image image, Int32 width, Int32 height)
        {
            Bitmap destImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(destImage))
                graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            return destImage;
        }
