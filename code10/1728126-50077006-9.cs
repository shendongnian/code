    public static Bitmap CreateGreyImage(Int32[,] greyChannel)
    {
        Int32 width = greyChannel.GetLength(1);
        Int32 height = greyChannel.GetLength(0);
        Bitmap result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        Rectangle rect = new Rectangle(0, 0, width, height);
        BitmapData bmpData = result.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
        Int32 stride = bmpData.Stride;
        // stride is the actual line width in bytes.
        Int32 bytes = stride * height;
        Byte[] PixelValues = new Byte[bytes];
        for (Int32 y = 0; y < height; y++)
        {
            // use stride to get the start offset of each line
            Int32 offset = y * stride;
            for (Int32 x = 0; x < width; x++)
            {
                PixelValues[offset + 0] = (Byte)greyChannel[y, x];
                PixelValues[offset + 1] = (Byte)greyChannel[y, x];
                PixelValues[offset + 2] = (Byte)greyChannel[y, x];
                offset += 3;
            }
        }
        Marshal.Copy(PixelValues, 0, bmpData.Scan0, bytes);
        result.UnlockBits(bmpData);
        return result;
    }
