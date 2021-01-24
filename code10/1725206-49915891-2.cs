    public static Array2D<Byte> ToArray2D(this Bitmap bitmap)
    {
        Int32 stride;
        Byte[] data;
        // Removes unnecessary getter calls.
        Int32 width = bitmap.Width;
        Int32 height = bitmap.Height;
        // 'using' block to properly dispose temp image.
        using (Bitmap grayImage = MakeGrayscale3(bitmap))
        {
            BitmapData bits = grayImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);
            stride = bits.Stride;
            Int32 length = stride * height;
            data = new Byte[length];
            Marshal.Copy(bits.Scan0, data, 0, length);
            grayImage.UnlockBits(bits);
        }
        Array2D<Byte> array = new Array2D<Byte>(bitmap.Width, bitmap.Height);
        Int32 offset = 0;
        for (Int32 y = 0; y < height; x++)
        {
            // Offset variable for processing one line
            Int32 curOffset = offset
            for (var x = 0; x < width; x++)
            {
                array[x][y] = data[curOffset]; // Should be the Blue component.
                curOffs += 4;
            }
            // Stride is the actual data length of one line. No need to calculate that;
            // not only is it already given by the BitmapData object, but in some situations
            // it may differ from the actual data length. This also saves processing time
            // by avoiding multiplications inside each loop.
            offset += stride;
        }
        return array;
    }
