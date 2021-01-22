    public class ImageRotator
    {
        private readonly Bitmap image;
        public Image OriginalImage
        {
            get { return image; }
        }
     
     
        private ImageRotator(Bitmap image)
        {
            this.image = image;
        }
     
     
        private double GetRadian(double degree)
        {
            return degree * Math.PI / (double)180;
        }
     
     
        private Size CalculateSize(double angle)
        {
            double radAngle = GetRadian(angle);
            int width = (int)(image.Width * Math.Cos(radAngle) + image.Height * Math.Sin(radAngle));
            int height = (int)(image.Height * Math.Cos(radAngle) + image.Width * Math.Sin(radAngle));
            return new Size(width, height);
        }
     
        private PointF GetTopCoordinate(double radAngle)
        {
            Bitmap image = CurrentlyViewedMappedImage.BitmapImage;
            double topX = 0;
            double topY = 0;
     
            if (radAngle > 0)
            {
                topX = image.Height * Math.Sin(radAngle);
            }
            if (radAngle < 0)
            {
                topY = image.Width * Math.Sin(-radAngle);
            }
            return new PointF((float)topX, (float)topY);
        }
     
        public Bitmap RotateImage(double angle)
        {
            SizeF size = CalculateSize(radAngle);
            Bitmap rotatedBmp = new Bitmap((int)size.Width, (int)size.Height);
     
            Graphics g = Graphics.FromImage(rotatedBmp);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
     
            g.TranslateTransform(topPoint.X, topPoint.Y);
            g.RotateTransform(GetDegree(radAngle));
            g.DrawImage(image, new RectangleF(0, 0, size.Width, size.Height));
            
            g.Dispose();
            return rotatedBmp;
        }
     
     
        public static class Builder
        {
            public static ImageRotator CreateInstance(Image image)
            {
                ImageRotator rotator = new ImageRotator(image as Bitmap);
                return rotator;
            }
        }
    }
