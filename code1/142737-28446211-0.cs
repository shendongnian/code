        private bool AllOneColor(Bitmap bmp)
        {
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
            byte[] rgbValues = new byte[bmpData.Stride * bmp.Height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, rgbValues, 0, rgbValues.Length);
            bmp.UnlockBits(bmpData);
            return rgbValues.All(v => v == rgbValues[0]);
        }
