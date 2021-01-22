        public static void Negate(Bitmap image)
        {
            const int RED_PIXEL = 2;
            const int GREEN_PIXEL = 1;
            const int BLUE_PIXEL = 0;
            BitmapData bmData = currentImage.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);
            try
            {
                int stride = bmData.Stride;
                int bytesPerPixel = (currentImage.PixelFormat == PixelFormat.Format24bppRgb ? 3 : 4);
                
                unsafe
                {
                    byte* pixel = (byte*)(void*)bmData.Scan0;
                    int yMax = image.Height;
                    int xMax = image.Width;
                    for (int y = 0; y < yMax; y++)
                    {
                        int yPos = y * stride;
                        for (int x = areaSize.X; x < xMax; x++)
                        {
                            int pos = yPos + (x * bytesPerPixel);
                            pixel[pos + RED_PIXEL] = (byte)(255 - pixel[pos + RED_PIXEL]);
                            pixel[pos + GREEN_PIXEL] = (byte)(255 - pixel[pos + GREEN_PIXEL]);
                            pixel[pos + BLUE_PIXEL] = (byte)(255 - pixel[pos + BLUE_PIXEL]);                                                    
                        }
                        
                    }
                }
            }
            finally
            {
                image.UnlockBits(bmData);
            }
            
        }
