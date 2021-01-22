        private static unsafe Bitmap DuplicateBitmap(Bitmap inputBitmap)
        {
            byte[] buffer = new byte[inputBitmap.Height * inputBitmap.Width * Image.GetPixelFormatSize(inputBitmap.PixelFormat) / 8];
           
            fixed (byte* p = buffer)
            {
                BitmapData b1Data = new BitmapData()
                {
                    Scan0 = (IntPtr)p,
                    Height = inputBitmap.Height,
                    Width = inputBitmap.Width,
                    PixelFormat = inputBitmap.PixelFormat,
                    Stride = inputBitmap.Width * Image.GetPixelFormatSize(inputBitmap.PixelFormat) / 8,
                };  
             
                inputBitmap.LockBits(new Rectangle(Point.Empty, inputBitmap.Size),
                    ImageLockMode.ReadOnly | ImageLockMode.UserInputBuffer, inputBitmap.PixelFormat, b1Data); // copy out.
                
                Bitmap b2 = new Bitmap(b1Data.Width, b1Data.Height, b1Data.Stride, inputBitmap.PixelFormat, b1Data.Scan0);
                
                inputBitmap.UnlockBits(b1Data);
                
                return b2;
            }
        }
