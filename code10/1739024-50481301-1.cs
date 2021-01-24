    RectangleF visibleImageRegion;
    Bitmap result;
    double zoomFactor;
    int w;
    int h;
    visibleImageRegion = imageBox.GetSourceImageRegion();
    zoomFactor = imageBox.ZoomFactor;
    w = Convert.ToInt32(visibleImageRegion.Width * zoomFactor);
    h = Convert.ToInt32(visibleImageRegion.Height * zoomFactor);
    result = new Bitmap(w, h);
    using (Graphics g = Graphics.FromImage(result))
    {
      g.PixelOffsetMode = PixelOffsetMode.HighQuality;
      g.InterpolationMode = InterpolationMode.HighQualityBicubic;
      g.DrawImage(imageBox.Image, new Rectangle(0, 0, w, h), visibleImageRegion, GraphicsUnit.Pixel);
    }
