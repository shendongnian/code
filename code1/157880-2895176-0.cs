        public Color GetPixel(BitmapSource bitmap, int x, int y)
        {
            Debug.Assert(bitmap != null);
            Debug.Assert(x >= 0);
            Debug.Assert(y >= 0);
            Debug.Assert(x < bitmap.PixelWidth);
            Debug.Assert(y < bitmap.PixelHeight);
            Debug.Assert(bitmap.Format.BitsPerPixel >= 24);
            CroppedBitmap cb = new CroppedBitmap(bitmap, new Int32Rect(x, y, 1, 1));
            byte[] pixel = new byte[bitmap.Format.BitsPerPixel / 8];
            cb.CopyPixels(pixel, bitmap.Format.BitsPerPixel / 8, 0);
            return Color.FromRgb(pixel[2], pixel[1], pixel[0]);
        }
