    public static Bitmap GetGreyImage(Image img, Int32 width, Int32 height)
    {
        // get image data
        Bitmap b = new Bitmap(img, width, height);
        BitmapData sourceData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        Int32 stride = sourceData.Stride;
        Byte[] data = new Byte[stride * b.Height];
        // Copy bytes from image into data array
        Marshal.Copy(sourceData.Scan0, data, 0, data.Length);
        // iterate over array and convert to gray
        for (Int32 y = 0; y < height; y++)
        {
            Int32 offset = y * stride;
            for (Int32 x = 0; x < width; x++)
            {
                // "ARGB" is little-endian Int32, so the actual byte order is B,G,R,A
                Byte colB = data[offset + 0]; // B
                Byte colG = data[offset + 1]; // G
                Byte colR = data[offset + 2]; // R
                Int32 colA = data[offset + 3]; // A
                // Optional improvement: set pixels to black if color
                // is considered too transparent to matter.
                Byte grayValue = colA < 128 ? 0 : GetGreyValue(colR, colG, colB);
                data[offset + 0] = grayValue; // B
                data[offset + 1] = grayValue; // G
                data[offset + 2] = grayValue; // R
                data[offset + 3] = 0xFF; // A
                offset += 4;
            }
        }
        // Copy bytes from data array back into image
        Marshal.Copy(data, 0, sourceData.Scan0, data.Length);
        b.UnlockBits(sourceData);
        return b;
    }
