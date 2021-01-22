            // get the raw image data
            int width, height;
            int[] data = GetData(out width, out height);
            
            // create a bitmap and manipulate it
            Bitmap bmp = new Bitmap(width,height, PixelFormat.Format32bppArgb);
            BitmapData bits = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            unsafe
            {
                for (int y = 0; y < height; y++)
                {
                    byte* row = (byte*)bits.Scan0 + (y * bits.Stride);
                    for (int x = 0; x < width; x++)
                    {
                        int val = data[y * width + x];
                        row[x * 4] = (byte)val;             // B
                        row[x * 4 + 1] = (byte)(val >> 8);  // G
                        row[x * 4 + 2] = (byte)(val >> 16); // R
                        row[x * 4 + 3] = (byte)(val >> 24); // A
                    }
                }
            }
            bmp.UnlockBits(bits);
