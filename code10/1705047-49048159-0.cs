        private unsafe Task<Bitmap> BitmapFromArray(Int32[,] pixels, int width, int height)
        {
            return Task.Run(() =>
             {
                 Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                 BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                 for (int y = 0; y < height; y++)
                 {
                     byte* row = (byte*)bitmapData.Scan0 + bitmapData.Stride * y;
                     for (int x = 0; x < width; x++)
                     {
                         byte grayShade8bit = (byte)(pixels[x, y]);
                         row[x * 3 + 0] = grayShade8bit;
                         row[x * 3 + 1] = grayShade8bit;
                         row[x * 3 + 2] = grayShade8bit;
                     }
                 }
                 bitmap.UnlockBits(bitmapData);
                 return bitmap;
             });
        }
