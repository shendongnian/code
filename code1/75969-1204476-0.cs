    [Serializable]
    public class BitmapTransfer
    {
        private byte[] buffer;
        private PixelFormat pixelFormat;
        private Size size;
        private float dpiX;
        private float dpiY;
    
        public BitmapTransfer(Bitmap source)
        {
            this.pixelFormat = source.PixelFormat;
            this.size = source.Size;
            this.dpiX = source.HorizontalResolution;
            this.dpiY = source.VerticalResolution;
            BitmapData bitmapData = source.LockBits(
                new Rectangle(new Point(0, 0), source.Size),
                ImageLockMode.ReadOnly, 
                source.PixelFormat);
            IntPtr ptr = bitmapData.Scan0;
            int bufferSize = bitmapData.Stride * bitmapData.Height;
            this.buffer = new byte[bufferSize];
            System.Runtime.InteropServices.Marshal.Copy(ptr, buffer, 0, bufferSize);
            source.UnlockBits(bitmapData);
        }
    
        public Bitmap ToBitmap()
        {
            Bitmap bitmap = new Bitmap(
                this.size.Width,
                this.size.Height,
                this.pixelFormat);
            bitmap.SetResolution(this.dpiX, this.dpiY);
            BitmapData bitmapData = bitmap.LockBits(
                new Rectangle(new Point(0, 0), bitmap.Size),
                ImageLockMode.WriteOnly, bitmap.PixelFormat);
            IntPtr ptr = bitmapData.Scan0;
            int bufferSize = bitmapData.Stride * bitmapData.Height;
            System.Runtime.InteropServices.Marshal.Copy(this.buffer, 0, ptr, bufferSize);
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }
    }
