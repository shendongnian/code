        public static Size CalculateResizeToFit(Size imageSize, Size boxSize)
        {
            // TODO: Check for arguments (for null and <=0)
            var widthScale = boxSize.Width / (double)imageSize.Width;
            var heightScale = boxSize.Height / (double)imageSize.Height;
            var scale = Math.Min(widthScale, heightScale);
            return new Size(
                (int)Math.Round((imageSize.Width * scale)),
                (int)Math.Round((imageSize.Height * scale))
                );
        }
