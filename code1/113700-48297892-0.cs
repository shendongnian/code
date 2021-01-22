        public static Bitmap CreateResizedBitmap(Bitmap logicalImage, Size targetImageSize)
        {
            if (logicalImage == null)
            {
                return null;
            }
 
            return ScaleBitmapToSize(logicalImage, targetImageSize);
        } private static Bitmap ScaleBitmapToSize(Bitmap logicalImage, Size deviceImageSize)
        {
            Bitmap deviceImage;
            deviceImage = new Bitmap(deviceImageSize.Width, deviceImageSize.Height, logicalImage.PixelFormat);
 
            using (Graphics graphics = Graphics.FromImage(deviceImage))
            {
                graphics.InterpolationMode = InterpolationMode;
 
                RectangleF sourceRect = new RectangleF(0, 0, logicalImage.Size.Width, logicalImage.Size.Height);
                RectangleF destRect = new RectangleF(0, 0, deviceImageSize.Width, deviceImageSize.Height);
 
                // Specify a source rectangle shifted by half of pixel to account for GDI+ considering the source origin the center of top-left pixel
                // Failing to do so will result in the right and bottom of the bitmap lines being interpolated with the graphics' background color,
                // and will appear black even if we cleared the background with transparent color. 
                // The apparition of these artifacts depends on the interpolation mode, on the dpi scaling factor, etc.
                // E.g. at 150% DPI, Bicubic produces them and NearestNeighbor is fine, but at 200% DPI NearestNeighbor also shows them.
                sourceRect.Offset(-0.5f, -0.5f);
 
                graphics.DrawImage(logicalImage, destRect, sourceRect, GraphicsUnit.Pixel);
            }
 
            return deviceImage;
        }
