    /// <summary>
    /// Gets the raw bytes from an image.
    /// </summary>
    /// <param name="sourceImage">The image to get the bytes from.</param>
    /// <param name="stride">Stride of the retrieved image data.</param>
    /// <param name="collapseStride">Collapse the stride to the minimum required for the image data.</param>
    /// <returns>The raw bytes of the image.</returns>
    public static Byte[] GetImageData(Bitmap sourceImage, out Int32 stride, Boolean collapseStride)
    {
        if (sourceImage == null)
            throw new ArgumentNullException("sourceImage", "Source image is null!");
        Int32 width = sourceImage.Width;
        Int32 height = sourceImage.Height;
        BitmapData sourceData = sourceImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, sourceImage.PixelFormat);
        stride = sourceData.Stride;
        Byte[] data;
        if (collapseStride)
        {
            Int32 actualDataWidth = ((Image.GetPixelFormatSize(sourceImage.PixelFormat) * width) + 7) / 8;
            Int64 sourcePos = sourceData.Scan0.ToInt64();
            Int32 destPos = 0;
            data = new Byte[actualDataWidth * height];
            for (Int32 y = 0; y < height; ++y)
            {
                Marshal.Copy(new IntPtr(sourcePos), data, destPos, actualDataWidth);
                sourcePos += stride;
                destPos += actualDataWidth;
            }
            stride = actualDataWidth;
        }
        else
        {
            data = new Byte[stride * height];
            Marshal.Copy(sourceData.Scan0, data, 0, data.Length);
        }
        sourceImage.UnlockBits(sourceData);
        return data;
    }
