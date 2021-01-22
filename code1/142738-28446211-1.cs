        private bool AllOneColor(Bitmap bmp)
        {
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            byte[] rgbValues = new byte[bmpData.Stride * bmpData.Height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, rgbValues, 0, rgbValues.Length);
            bmp.UnlockBits(bmpData);
            return !rgbValues.Where((v, i) => i % bmpData.Stride < bmp.Width && v != rgbValues[0]).Any();
        }
