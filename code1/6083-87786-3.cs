    Bitmap newImage = new Bitmap(newWidth, newHeight);
    using (Graphics gr = Graphics.FromImage(newImage))
    {
        gr.SmoothingMode = SmoothingMode.HighQuality;
        gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
        gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
        gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
    }
