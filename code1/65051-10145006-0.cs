        private long[] GetHistogram(Bitmap image)
        {
            var histogram = new long[256];
            bool imageWasCloned = false;
            if (image.PixelFormat != PixelFormat.Format24bppRgb)
            {
                //the unsafe code expects Format24bppRgb, so convert the image...
                image = image.Clone(new Rectangle(0, 0, image.Width, image.Height), PixelFormat.Format24bppRgb);
                imageWasCloned = true;
            }
            BitmapData bmd = null;
            try
            {
                bmd = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly,
                                     PixelFormat.Format24bppRgb);
                const int pixelSize = 3; //pixels are 3 bytes each w/ Format24bppRgb
                //For info on locking the bitmap bits and finding the 
                //pixels using unsafe code, see http://www.bobpowell.net/lockingbits.htm
                int height = bmd.Height;
                int width = bmd.Width;
                int rowPadding = bmd.Stride - (width * pixelSize);
                unsafe
                {
                    byte* pixelPtr = (byte*)bmd.Scan0;//starts on the first row
                    for (int y = 0; y < height; ++y)
                    {
                        for (int x = 0; x < width; ++x)
                        {
                            histogram[(pixelPtr[0] + pixelPtr[1] + pixelPtr[2]) / 3]++;
                            pixelPtr += pixelSize;//advance to next pixel in the row
                        }
                        pixelPtr += rowPadding;//advance ptr to the next pixel row by skipping the padding @ the end of each row.
                    }
                }
            }
            finally
            {
                if (bmd != null)
                    image.UnlockBits(bmd);
                if (imageWasCloned)
                    image.Dispose();
            }
            return histogram;
        }
