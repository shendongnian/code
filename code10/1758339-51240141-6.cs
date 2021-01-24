        private int CountPixels(Bitmap bm, Color target_color, float tolerancePercent)
        {
            int matches = 0;
            Bitmap bmp = bm.Clone();
            BitmapData bmpDat = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            int size = bmpDat.Stride * bmpDat.Height;
            byte[] subPx = new byte[size];
            System.Runtime.InteropServices.Marshal.Copy(bmpDat.Scan0, subPx, 0, size);
            for (int i = 0; i < size; i += 3 )
            {
                float distancePercent = Math.Sqrt(
                    Math.Abs(target_color.R-subPx[i]) + 
                    Math.Abs(target_color.G-subPx[i+1]) + 
                    Math.Abs(target_color.B-subPx[i+2])
                ) / 7.65;
                if(distancePercent < tolerancePercent)
                {
                    matches++;
                }
            }
            System.Runtime.InteropServices.Marshal.Copy(subPx, 0, bmpDat.Scan0, subPx.Length);
            bmp.UnlockBits(bmpDat);
            return matches;
        }
