    public class SomeImageType : IDisposable
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public PixelFormat PixelFormat { get; private set; }
        IntPtr ImageData { get; private set; }
        // implementation of constructor and IDisposable not shown
    }
