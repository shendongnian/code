    /// <summary>
    /// Resize the image to the given Size
    /// </summary>
    /// <param name="img">Current Image</param>
    /// <param name="width">Width size</param>
    /// <param name="height">Height size</param>
    /// <returns>Resized Image</returns>
    public static Image Resize(this Image img, int width, int height)
    {
        return img.GetThumbnailImage(width, height, null, IntPtr.Zero);
    }
