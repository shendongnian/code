    public static Bitmap CreateGreyImage(Int32[,] greyChannel)
    {
        Int32 width = greyChannel.GetLength(0);
        Int32 height = greyChannel.GetLength(1);
        Bitmap result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        Rectangle rect = new Rectangle(0, 0, width, height);
        BitmapData bmpData = result.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
        Int32 stride = bmpData.Stride;
        // stride is the actual line width in bytes.
        Int32 bytes = stride * height;
        Byte[] pixelValues = new Byte[bytes];
        Int32 offset = 0;
        for (Int32 y = 0; y < height; y++)
        {
            Int32 workOffset = offset;
            for (Int32 x = 0; x < width; x++)
            {
                pixelValues[workOffset + 0] = (Byte)greyChannel[x, y];
                pixelValues[workOffset + 1] = (Byte)greyChannel[x, y];
                pixelValues[workOffset + 2] = (Byte)greyChannel[x, y];
                workOffset += 3;
            }
            // Add stride to get the start offset of the next line
            offset += stride;
        }
        Marshal.Copy(pixelValues, 0, bmpData.Scan0, bytes);
        result.UnlockBits(bmpData);
        return result;
    }
