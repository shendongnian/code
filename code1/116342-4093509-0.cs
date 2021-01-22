    /// <summary>
    /// Resize image to max dimensions
    /// </summary>
    /// <param name="img">Current Image</param>
    /// <param name="maxWidth">Max width</param>
    /// <param name="maxHeight">Max height</param>
    /// <returns>Scaled image</returns>
    public static Image Scale(this Image img, int maxWidth, int maxHeight)
    {
        double scale = 1;
        if (img.Width > maxWidth || img.Height > maxHeight)
        {
            double scaleW, scaleH;
            scaleW = maxWidth / (double)img.Width;
            scaleH = maxHeight / (double)img.Height;
            scale = scaleW < scaleH ? scaleW : scaleH;
        }
        return img.Resize((int)(img.Width * scale), (int)(img.Height * scale));
    }
    /// <summary>
    /// Resize image to max dimensions
    /// </summary>
    /// <param name="img">Current Image</param>
    /// <param name="maxDimensions">Max image size</param>
    /// <returns>Scaled image</returns>
    public static Image Scale(this Image img, Size maxDimensions)
    {
        return img.Scale(maxDimensions.Width, maxDimensions.Height);
    }
