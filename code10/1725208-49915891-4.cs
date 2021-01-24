    public static Array2D<Byte> ToArray2D(this Bitmap bitmap)
    {
        Int32 stride;
        Byte[] data;
        // Removes unnecessary getter calls.
        Int32 width = bitmap.Width;
        Int32 height = bitmap.Height;
        // 'using' block to properly dispose temp image.
        using (Bitmap grayImage = MakeGrayscale(bitmap))
        {
            BitmapData bits = grayImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
            stride = bits.Stride;
            Int32 length = stride*height;
            data = new Byte[length];
            Marshal.Copy(bits.Scan0, data, 0, length);
            grayImage.UnlockBits(bits);
        }
        // Constructor is (rows, columns), so (height, width)
        Array2D<Byte> array = new Array2D<Byte>(height, width);
        Int32 offset = 0;
        for (Int32 y = 0; y < height; y++)
        {
            // Offset variable for processing one line
            Int32 curOffset = offset;
            // Get row in advance
            Array2D<Byte>.Row<Byte> curRow = array[y];
            for (Int32 x = 0; x < width; x++)
            {
                curRow[x] = data[curOffset]; // Should be the Blue component.
                curOffset += 4;
            }
            // Stride is the actual data length of one line. No need to calculate that;
            // not only is it already given by the BitmapData object, but in some situations
            // it may differ from the actual data length. This also saves processing time
            // by avoiding multiplications inside each loop.
            offset += stride;
        }
        return array;
    }
