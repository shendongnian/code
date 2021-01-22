    public bool GenerateThumbNail(string fileName, string thumbNailFileName,
        ImageFormat format, int height, int width)
    {
        try
        {
            using (Image img = Image.FromFile(fileName))
            {
                Image thumbNail = new Bitmap(width, height, img.PixelFormat);
                Graphics g = Graphics.FromImage(thumbNail);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Rectangle rect = new Rectangle(0, 0, width, height);
                g.DrawImage(img, rect);
                thumbNail.Save(thumbNailFileName, format);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
