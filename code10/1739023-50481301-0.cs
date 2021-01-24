    Rectangle visibleImageRegion;
    Bitmap result;
    
    visibleImageRegion = Rectangle.Round(imageBox.GetSourceImageRegion());
    result = new Bitmap(visibleImageRegion.Width, visibleImageRegion.Height);
    
    using (Graphics g = Graphics.FromImage(result))
    {
      g.DrawImage(imageBox.Image, new Rectangle(Point.Empty, visibleImageRegion.Size), visibleImageRegion, GraphicsUnit.Pixel);
    }
