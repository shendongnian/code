            // get the raw image data
            int width, height;
            int[] data = GetData(out width, out height);
            
            // create a bitmap and manipulate it
            Bitmap bmp = new Bitmap(width,height, PixelFormat.Format32bppArgb);
            BitmapData bits = bmp.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, bmp.PixelFormat);
            unsafe
            {
                for (int y = 0; y < height; y++)
                {
                    int* row = (int*)((byte*)bits.Scan0 + (y * bits.Stride));
                    for (int x = 0; x < width; x++)
                    {
                        row[x] = data[y * width + x];
                    }
                }
            }
            bmp.UnlockBits(bits);
