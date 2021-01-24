        private int CountPixels(Bitmap bm, Color target_color)
        {
            int matches = 0;
            Bitmap bmp = bm.Clone();
            BitmapData bmpDat = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            int size = bmpDat.Stride * bmpDat.Height;
            byte[] subPx = new byte[size];
            System.Runtime.InteropServices.Marshal.Copy(bmpDat.Scan0, subPx, 0, size);
            //change the 3 (RGB) to a 4 (RGBA) if you have an alpha channel, this is for 24bpp images which I believe yours will be
            for (int i = 0; i < size; i += 3 )
            {
                if(new Color(subPx[i],subPx[i + 1],subPx[i + 2]) == target_color)
                {
                    matches++;
                }
            }
            System.Runtime.InteropServices.Marshal.Copy(subPx, 0, bmpDat.Scan0, subPx.Length);
            bmp.UnlockBits(bmpDat);
            return matches;
        }
