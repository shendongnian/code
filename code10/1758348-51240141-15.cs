        private int CountPixels(Bitmap bm, Color target_color, float tolerancePercent)
        {
            int matches = 0;
            Bitmap bmp = (Bitmap)bm.Clone();
            BitmapData bmpDat = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            int size = bmpDat.Stride * bmpDat.Height;
            byte[] subPx = new byte[size];
            System.Runtime.InteropServices.Marshal.Copy(bmpDat.Scan0, subPx, 0, size);
            for (int i = 0; i < size; i += 4 )
            {
                byte r = BitConverter.IsLittleEndian ? subPx[i+2] : subPx[i+3];
                byte g = BitConverter.IsLittleEndian ? subPx[i+1] : subPx[i+2];
                byte b = BitConverter.IsLittleEndian ? subPx[i] : subPx[i+1];
                float distancePercent = (float)Math.Sqrt(
                    Math.Abs(target_color.R-r) + 
                    Math.Abs(target_color.G-g) + 
                    Math.Abs(target_color.B-b)
                ) / 7.65f;
                if(distancePercent < tolerancePercent)
                {
                    matches++;
                }
            }
            System.Runtime.InteropServices.Marshal.Copy(subPx, 0, bmpDat.Scan0, subPx.Length);
            bmp.UnlockBits(bmpDat);
            return matches;
        }
