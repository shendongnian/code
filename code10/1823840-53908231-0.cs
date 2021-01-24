    /// <summary>
    /// Gets the raw bytes from an image.
    /// </summary>
    /// <param name="sourceImage">The image to get the bytes from.</param>
    /// <returns>The raw bytes of the image</returns>
    public static Byte[] GetImageDataAs32bppArgb(Bitmap sourceImage)
    {
        BitmapData sourceData = sourceImage.LockBits(
            new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        Byte[] data = new Byte[sourceData.Stride * sourceImage.Height];
        Marshal.Copy(sourceData.Scan0, data, 0, data.Length);
        sourceImage.UnlockBits(sourceData);
        return data;
    }
