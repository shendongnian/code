    public void ResizeImage(double scaleFactor, Stream fromStream, Stream toStream)
    {
        using (var image = Image.FromStream(fromStream))
        {
            var newWidth = (int)(image.Width * scaleFactor);
            var newHeight = (int)(image.Height * scaleFactor);
            using (var thumbnailBitmap = new Bitmap(newWidth, newHeight))
            using (var thumbnailGraph = Graphics.FromImage(thumbnailBitmap))
            {
                thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbnailGraph.DrawImage(image, imageRectangle);
                thumbnailBitmap.Save(toStream, image.RawFormat);
            }
        }
    }
