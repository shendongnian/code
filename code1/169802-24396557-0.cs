    private static Bitmap ExtractImageRectangle(byte[] sourceBuffer, int sourceStride, PixelFormat sourcePixelFormat, Rectangle rectangle)
    {
        Bitmap result = new Bitmap(rectangle.Width, rectangle.Height, sourcePixelFormat);
        BitmapData resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.WriteOnly, result.PixelFormat);
        int bytesPerPixel = GetBytesPerPixel(sourcePixelFormat); // Left as an exercise for the reader
        try
        {
            // Bounds checking omitted for brevity
            for (int rowIndex = 0; rowIndex < rectangle.Height; ++rowIndex)
            {
                // The address of the start of this row in the destination image
                IntPtr destinationLineStart = resultData.Scan0 + resultData.Stride * rowIndex;
                // The index at which the current row of our rectangle starts in the source image
                int sourceIndex = sourceStride * (rowIndex + rectangle.Top) + rectangle.Left * bytesPerPixel;
                // Copy the row from the source to the destination
                Marshal.Copy(sourceBuffer, sourceIndex, destinationLineStart, rectangle.Width * bytesPerPixel);
            }
        }
        finally
        {
            result.UnlockBits(resultData);
        }
        return result;
    }
