           PixelFormat format = PixelFormat.Format8bppIndexed;
           Bitmap bmp = new Bitmap(Img_Width, Img_Height,format);
           Rectangle rect = new Rectangle(0, 0, Img_Width, Img_Height);
           //locking the bitmap on memory
           BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, format);
           Marshal.Copy(rawPixel, 0, bmpData.Scan0, rawPixel.Length);
           int stride = bmpData.Stride;
           System.IntPtr Scan0 = bmpData.Scan0;
           unsafe
           {
               byte* p = (byte*)(void*)Scan0;
               int nOffset = stride - bmp.Width * SAMPLES_PER_PIXEL ;
               byte red, green, blue;
               for (int y = 0; y < bmp.Height; ++y)
                {
                    for (int x = 0; x < bmp.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];
                        p[0] = red;
                        p[1] = green;
                        p[2] = blue;
                        p += 3;
                    }
                    p += nOffset;
                }
            }
            ////unlockimg the bitmap
            bmp.UnlockBits(bmpData);
