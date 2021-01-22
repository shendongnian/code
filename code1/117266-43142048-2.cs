    /// <summary>
    /// Creates a bitmap based on data, width, height, stride and pixel format.
    /// </summary>
    /// <param name="sourceData">Byte array of raw source data</param>
    /// <param name="width">Width of the image</param>
    /// <param name="height">Height of the image</param>
    /// <param name="stride">Scanline length inside the data</param>
    /// <param name="pixelFormat"></param>
    /// <param name="palette">Color palette</param>
    /// <returns>The new image</returns>
    public static Bitmap BuildImage(Byte[] sourceData, Int32 width, Int32 height, Int32 stride, PixelFormat pixelFormat, Color[] palette)
    {
        if (width == 0 || height == 0)
            return null;
        Bitmap newImage = new Bitmap(width, height, pixelFormat);
        BitmapData targetData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, newImage.PixelFormat);
        CopyMemory(targetData.Scan0, sourceData, sourceData.Length, stride, targetData.Stride);
        newImage.UnlockBits(targetData);
        // For 8-bit images, set the palette.
        if ((pixelFormat == PixelFormat.Format8bppIndexed || pixelFormat == PixelFormat.Format4bppIndexed) && palette != null)
        {
            ColorPalette pal = newImage.Palette;
            for (Int32 i = 0; i < pal.Entries.Length; i++)
                if (i < palette.Length)
                pal.Entries[i] = palette[i];
            newImage.Palette = pal;
        }
        return newImage;
    }
