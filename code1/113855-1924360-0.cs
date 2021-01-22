    public class DoubleBufferedGraphics : IDisposable
    {
        #region Constructor
        public DoubleBufferedGraphics() : this(0, 0) { }
        public DoubleBufferedGraphics(int width, int height)
        {
            Height = height;
            Width = width;
        }
        #endregion
        #region Private Fields
        private Image _MemoryBitmap;
        #endregion
        #region Public Properties
        public Graphics Graphics { get; private set; }
        public int Height { get; private set; }
        public bool Initialized
        {
            get { return (_MemoryBitmap != null); }
        }
        public int Width { get; private set; }
        #endregion
        #region Public Methods
        public void Dispose()
        {
            if (_MemoryBitmap != null)
            {
                _MemoryBitmap.Dispose();
                _MemoryBitmap = null;
            }
            if (Graphics != null)
            {
                Graphics.Dispose();
                Graphics = null;
            }
        }
        public void Initialize(int width, int height)
        {
            if (height > 0 && width > 0)
            {
                if ((height != Height) || (width != Width))
                {
                    Height = height;
                    Width = width;
                    Reset();
                }
            }
        }
        public void Render(Graphics graphics)
        {
            if (_MemoryBitmap != null)
            {
                graphics.DrawImage(_MemoryBitmap, _MemoryBitmap.GetRectangle(), 0, 0, Width, Height, GraphicsUnit.Pixel);
            }
        }
        public void Reset()
        {
            if (_MemoryBitmap != null)
            {
                _MemoryBitmap.Dispose();
                _MemoryBitmap = null;
            }
            if (Graphics != null)
            {
                Graphics.Dispose();
                Graphics = null;
            }
            _MemoryBitmap = new Bitmap(Width, Height);
            Graphics = Graphics.FromImage(_MemoryBitmap);
        }
        /// <summary>
        /// This method is the preferred method of drawing a background image.
        /// It is *MUCH* faster than any of the Graphics.DrawImage() methods.
        /// Warning: The memory image and the <see cref="Graphics"/> object
        /// will be reset after calling this method. This should be your first
        /// drawing operation.
        /// </summary>
        /// <param name="image">The image to draw.</param>
        public void SetBackgroundImage(Image image)
        {
            if (_MemoryBitmap != null)
            {
                _MemoryBitmap.Dispose();
                _MemoryBitmap = null;
            }
            if (Graphics != null)
            {
                Graphics.Dispose();
                Graphics = null;
            }
            _MemoryBitmap = image.Clone() as Image;
            if (_MemoryBitmap != null)
            {
                Graphics = Graphics.FromImage(_MemoryBitmap);
            }
        }
        #endregion
    }
