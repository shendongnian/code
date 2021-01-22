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
        CopyToMemory(targetData.Scan0, sourceData, 0, sourceData.Length, stride, targetData.Stride);
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
        
    public static void CopyToMemory(IntPtr target, Byte[] bytes, Int32 startPos, Int32 length, Int32 origStride, Int32 targetStride)
    {
        Int32 sourcePos = startPos;
        IntPtr destPos = target;
        Int32 minStride = Math.Min(origStride, targetStride);
        while (length >= targetStride)
        {
            Marshal.Copy(bytes, sourcePos, destPos, minStride);
            length -= origStride;
            sourcePos += origStride;
            destPos = new IntPtr(destPos.ToInt64() + targetStride);
        }
        if (length > 0)
        {
            Marshal.Copy(bytes, sourcePos, destPos, length);
        }
    }
