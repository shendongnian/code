     int pixelBPP = Image.GetPixelFormatSize(resultBmp.PixelFormat) / 8;
            unsafe
            {
                BitmapData bmpData = resultBmp.LockBits(new Rectangle(0, 0, resultBmp.Width, resultBmp.Height), ImageLockMode.ReadWrite, resultBmp.PixelFormat);
                byte* ptr = (byte*)bmpData.Scan0; //addres of first line
                int height = resultBmp.Height;
                int width = resultBmp.Width * pixelBPP;
                Parallel.For(0, height, y =>
                {
                    byte* offset = ptr + (y * bmpData.Stride); //set row
                    for(int x = 0; x < width; x = x + pixelBPP)
                    {
                        byte value = (offset[x] + offset[x + 1] + offset[x + 2]) / 3 > threshold ? Byte.MaxValue : Byte.MinValue;
                        offset[x] = value;
                        offset[x + 1] = value;
                        offset[x + 2] = value;
                        if (pixelBPP == 4)
                        {
                            offset[x + 3] = 255;
                        }
                    }
                });
                resultBmp.UnlockBits(bmpData);
            }
