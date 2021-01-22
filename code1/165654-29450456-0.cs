    public static class ImageHelper
    {
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
        public static Bitmap ResizeImage(Image image, decimal percentage)
        {
            int width = (int)Math.Round(image.Width * percentage, MidpointRounding.AwayFromZero);
            int height = (int)Math.Round(image.Height * percentage, MidpointRounding.AwayFromZero);
            return ResizeImage(image, width, height);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Images\MyImage.jpg";
            FileInfo info = new FileInfo(fileName);
            using (Image image = Image.FromFile(fileName))
            {
                using(Bitmap resizedImage = ImageHelper.ResizeImage(image, 0.25m))
                {
                    resizedImage.Save(
                        info.DirectoryName + "\\" 
                            + info.Name.Substring(0, info.Name.LastIndexOf(info.Extension)) 
                            + "_" + resizedImage.Width + "_" + resizedImage.Height 
                            + info.Extension, 
                        ImageFormat.Jpeg);
                }
            }
        }
    }
