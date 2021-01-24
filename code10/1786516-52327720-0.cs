    public static byte[] GetImageRaw(Bitmap image)
    {
        if (image == null)
        {
            throw new ArgumentNullException(nameof(image));
        }
        if (image.PixelFormat != PixelFormat.Format24bppRgb)
        {
            throw new NotSupportedException("Invalid pixel format.");
        }
        const int PixelSize = 3;
        var data = image.LockBits(
            new Rectangle(Point.Empty, image.Size),
            ImageLockMode.ReadWrite,
            image.PixelFormat);
        try
        {
            var bytes = new byte[data.Width * data.Height * PixelSize];
            for (var y = 0; y < data.Height; ++y)
            {
                var source = (IntPtr)((long)data.Scan0 + y * data.Stride);
                // copy row without padding
                Marshal.Copy(source, bytes, y * data.Width * PixelSize, data.Width * PixelSize);
            }
            return bytes;
        }
        finally
        {
            image.UnlockBits(data);
        }
    }
