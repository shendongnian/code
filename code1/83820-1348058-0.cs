        public static Icon Convert(BitmapImage bitmapImage)
        {
            System.Drawing.Bitmap bitmap = null;
            var width = bitmapImage.PixelWidth;
            var height = bitmapImage.PixelHeight;
            var stride = width * ((bitmapImage.Format.BitsPerPixel + 7) / 8);
            var bits = new byte[height * stride];
            bitmapImage.CopyPixels(bits, stride, 0);
            unsafe
            {
                fixed (byte* pB = bits)
                {
                    var ptr = new IntPtr(pB);
                    bitmap = new System.Drawing.Bitmap(width, height, stride,
                                                    System.Drawing.Imaging.PixelFormat.Format32bppPArgb,
                                                    ptr);
                }
            }
            return Icon.FromHandle(bitmap.GetHicon());
        }
