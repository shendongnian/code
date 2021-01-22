    /// <summary>
    /// Creates a bitmap based on data, width, height, stride and pixel format.
    /// </summary>
    /// <param name="sourceData">Byte array of raw source data</param>
    /// <param name="width">Width of the image</param>
    /// <param name="height">Height of the image</param>
    /// <param name="stride">Scanline length inside the data</param>
    /// <param name="pixelFormat">Pixel format</param>
    /// <param name="palette">Color palette</param>
    /// <param name="defaultColor">Default color to fill in on the palette if the given colors don't fully fill it.</param>
    /// <returns>The new image</returns>
    public static Bitmap BuildImage(Byte[] sourceData, Int32 width, Int32 height, Int32 stride, PixelFormat pixelFormat, Color[] palette, Color? defaultColor)
    {
        Bitmap newImage = new Bitmap(width, height, pixelFormat);
        BitmapData targetData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, newImage.PixelFormat);
        Int32 newDataWidth = ((Image.GetPixelFormatSize(pixelFormat) * width) + 7) / 8;
        Int32 targetStride = targetData.Stride;
        Int64 scan0 = targetData.Scan0.ToInt64();
        for (Int32 y = 0; y < height; y++)
            Marshal.Copy(sourceData, y * stride, new IntPtr(scan0 + y * targetStride), newDataWidth);
        newImage.UnlockBits(targetData);
        // For indexed images, set the palette.
        if ((pixelFormat & PixelFormat.Indexed) != 0 && palette != null)
        {
            ColorPalette pal = newImage.Palette;
            for (Int32 i = 0; i < pal.Entries.Length; i++)
            {
                if (i < palette.Length)
                    pal.Entries[i] = palette[i];
                else if (defaultColor.HasValue)
                    pal.Entries[i] = defaultColor.Value;
                else
                    break;
            }
            newImage.Palette = pal;
        }
        return newImage;
    }
