    public Stream ShowImage()
    {
        MemoryStream image =  new Bitmap(@"C:\Cover.png");
        Image image2 = new Bitmap(125, 125);
        
        using (Graphics graphics = Graphics.FromImage(image2))
        {
               graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
               graphics.SmoothingMode = SmoothingMode.HighQuality;
               graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
               graphics.CompositingQuality = CompositingQuality.HighQuality;
               graphics.DrawImage(image, 0, 0, 125, 125);
        }
        MemoryStream imageAsMemoryStream = new MemoryStream();
        image2.Save(imageAsMemoryStream, ImageFormat.Png);
        imageAsMemoryStream.Position = 0;
        return imageAsMemoryStream;
    }
