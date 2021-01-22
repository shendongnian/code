    public static Image Scale(Image sourceImage, int destWidth, int destHeight)
    {
        var toReturn = new Bitmap(destWidth, destHeight);
        using (var graphics = Graphics.FromImage(toReturn))
        using (var attributes = new ImageAttributes())
        {
            toReturn.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
            attributes.SetWrapMode(WrapMode.TileFlipXY);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.Half;
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.DrawImage(sourceImage, Rectangle.FromLTRB(0, 0, destWidth, destHeight), 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel, attributes);
        }
        return toReturn;
    }
