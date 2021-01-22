    public unsafe class UnmanagedBitmap : IDisposable
    {
        private Bitmap bmp;
        private Rectangle rect;
        private int bytesPerPixel;
        private IntPtr bufferPtr;
        private byte* bufferBytes;
        private int size;
        private BitmapData bData;
        private ImageLockMode lockMode;
        private byte* scan0;
        public UnmanagedBitmap(Bitmap bmp, ImageLockMode lockMode)
        {
            this.bmp = bmp;
            this.lockMode = lockMode;
            bytesPerPixel = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
            size = bmp.Width * bmp.Height * bytesPerPixel;
            bufferPtr = Marshal.AllocHGlobal(size);
            bufferBytes = (byte*)bufferPtr;
            rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            bData = bmp.LockBits(rect, lockMode, bmp.PixelFormat);
            scan0 = (byte*)bData.Scan0.ToPointer();
        }
        public void Dispose()
        {
            bmp.UnlockBits(bData);
            Marshal.FreeHGlobal(bufferPtr);
        }
        public Span<byte> GetPixel(int x, int y)
        {
            var pixel = scan0 + y * bData.Stride * x * bytesPerPixel;
            return new Span<byte>(pixel, bytesPerPixel);
        }
    }
