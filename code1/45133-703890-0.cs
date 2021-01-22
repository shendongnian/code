    public bool ResizeImage(string fileName, string imgFileName,
        ImageFormat format, int percent)
    {
        try
        {
            using (Image img = Image.FromFile(fileName))
            {
                int width = img.Width * (percent * .01);
                int height = img.Height * (percent * .01);
                Image thumbNail = new Bitmap(width, height, img.PixelFormat);
                Graphics g = Graphics.FromImage(thumbNail);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Rectangle rect = new Rectangle(0, 0, width, height);
                g.DrawImage(img, rect);
                thumbNail.Save(imgFileName, format);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
