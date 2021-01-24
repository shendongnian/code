        private int CountPixels(Bitmap bm, Color target_color)
        {
            int matches = 0;
            Bitmap bmp = (Bitmap)bm.Clone();
            BitmapData bmpDat = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            int size = bmpDat.Stride * bmpDat.Height;
            byte[] subPx = new byte[size];
            System.Runtime.InteropServices.Marshal.Copy(bmpDat.Scan0, subPx, 0, size);
            //change the 4 (ARGB) to a 3 (RGB) if you don't have an alpha channel, this is for 32bpp images
            
            //ternary operator to check endianess of machine and organise pixel colors as A,R,G,B or B,G,R,A (little endian is reversed);
            Color temp = BitConverter.IsLittleEndian ? Color.FromArgb(subPx[i + 2], subPx[i + 1], subPx[i]) : Color.FromArgb(subPx[i + 1], subPx[i + 2], subPx[i + 3]);
            for (int i = 0; i < size; i += 4 ) //4 bytes per pixel A, R, G, B
            {
                if(temp.ToArgb() == target_color.ToArgb())
                {
                    matches++;
                }
            }
            System.Runtime.InteropServices.Marshal.Copy(subPx, 0, bmpDat.Scan0, subPx.Length);
            bmp.UnlockBits(bmpDat);
            return matches;
        }
