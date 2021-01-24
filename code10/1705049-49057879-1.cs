        public static Bitmap fromTwoDimIntArrayGray(Int32[,] data)
        {
            Int32 width = data.GetLength(0);
            Int32 height = data.GetLength(1);
            Int32 stride = width * 4;
            Int32 byteIndex = 0;
            Byte[] dataBytes = new Byte[height * stride];
            for (Int32 y = 0; y < height; y++)
            {
                for (Int32 x = 0; x < width; x++)
                {
                    // UInt32 0xAARRGGBB = Byte[] { BB, GG, RR, AA }
                    UInt32 val = (UInt32)data[x, y];
                    // This code clears out everything but a specific part of the value
                    // and then shifts the remaining piece down to the lowest byte
                    dataBytes[byteIndex + 0] = (Byte)(val & 0x000000FF); // B
                    dataBytes[byteIndex + 1] = (Byte)((val & 0x0000FF00) >> 08); // G
                    dataBytes[byteIndex + 2] = (Byte)((val & 0x00FF0000) >> 16); // R
                    dataBytes[byteIndex + 3] = (Byte)((val & 0xFF000000) >> 24); // A
                    // More efficient than multiplying
                    byteIndex+=4;
                }
            }
            return BuildImage(dataBytes, width, height, stride, PixelFormat.Format32bppArgb, null, null);
        }
