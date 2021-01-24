    BitmapData bmpData = resultBmp.LockBits(new Rectangle(0, 0, resultBmp.Width, resultBmp.Height), 
                                                    ImageLockMode.ReadWrite, 
                                                    resultBmp.PixelFormat
                                                    );
            int bytes = bmpData.Stride * resultBmp.Height;
            byte[] pixels = new byte[bytes];
            Marshal.Copy(bmpData.Scan0, pixels, 0, bytes); //loading bytes to memory
            int height = resultBmp.Height;
            int width  = resultBmp.Width;
            Parallel.For(0, height - 1, y => //seting 2s and 3s
            {
                int offset = y * stride; //row
                for (int x = 0; x < width - 1; x++)
                {
                    int positionOfPixel = x + offset + pixelFormat; //remember about pixel format!
                        //do what you want with pixel
                    }
                }
            });
           Marshal.Copy(pixels, 0, bmpData.Scan0, bytes); //copying bytes to bitmap
            resultBmp.UnlockBits(bmpData);
