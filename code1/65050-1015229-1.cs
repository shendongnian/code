        public void Histogram(double[] histogram, Rectangle roi)
        {
            BitmapData data = Util.SetImageToProcess(image, roi);
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                return;
            if (histogram.Length < Util.GrayLevels)
                return;
            histogram.Initialize();
            int width = data.Width;
            int height = data.Height;
            int offset = data.Stride - width;
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; ++x, ++ptr)
                        histogram[ptr[0]]++;
                    ptr += offset;
                }
            }
            image.UnlockBits(data);         
        }
        static public BitmapData SetImageToProcess(Bitmap image, Rectangle roi)
        {
            if (image != null)
                return image.LockBits(
                    roi,
                    ImageLockMode.ReadWrite,
                    image.PixelFormat);
            return null;
        }
