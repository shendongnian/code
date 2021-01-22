    /// <summary>
    /// Resize the image to the specified width and height.
    /// </summary>
    /// <param name="image">The image to resize.</param>
    /// <param name="width">The width to resize to.</param>
    /// <param name="height">The height to resize to.</param>
    /// <returns>The resized image.</returns>
    public static Bitmap ResizeImage(Image image, int width, int height)
    {
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);
    
        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        using (var grapics = Graphics.FromImage(destImage))
        {
            grapics.CompositingMode = CompositingMode.SourceCopy;
            grapics.CompositingQuality = CompositingQuality.HighQuality;
            grapics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grapics.SmoothingMode = SmoothingMode.HighQuality;
            grapics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                grapics.DrawImage(image, destRect, 0, 0, image.Width,image.Height, GraphicsUnit.Pixel, wrapMode);
            }
        }
        return destImage;
    }
