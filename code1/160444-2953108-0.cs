    public Bitmap Resize(Bitmap originalImage, int newWidth)
    {
        int newHeight = (int)Math.Round(originalImage.Height * (decimal)newWidth / originalImage.Width, 0);
        var destination = new Bitmap(newWidth, newHeight);
        using (Graphics g = Graphics.FromImage(destination))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
        }
        return destination;
    }
