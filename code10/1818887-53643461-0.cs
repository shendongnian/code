    public static System.Drawing.Bitmap Resize(string pathToOriginalFile, int MaxImageSizeToResize)
        {
            using (var image = System.Drawing.Image.FromFile(pathToOriginalFile))
            {
                return LocalGet(image);
            }
            System.Drawing.Bitmap LocalGet(System.Drawing.Image image)
            {
                int rW = 0;
                int rH = 0;
                double c = 0;
                c = ((double)image.Height / (double)MaxImageSizeToResize);
                rW = (int)(image.Width / c);
                rH = MaxImageSizeToResize;
                var destRect = new System.Drawing.Rectangle(0, 0, rW, rH);
                var destImage = new System.Drawing.Bitmap(rW, rH);
                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                using (var graphics = System.Drawing.Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel, wrapMode);
                    }
                }
                return destImage;
            }
        }
