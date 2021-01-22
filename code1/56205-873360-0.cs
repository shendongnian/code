    public unsafe class RawBitmap : IDisposable
    {
        private BitmapData _bitmapData;
        private byte* _begin;
    
        public RawBitmap(Bitmap originBitmap)
        {
            OriginBitmap = originBitmap;
            _bitmapData = OriginBitmap.LockBits(new Rectangle(0, 0, OriginBitmap.Width, OriginBitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            _begin = (byte*)(void*)_bitmapData.Scan0;
        }
    
        #region IDisposable Members
    
        public void Dispose()
        {
            OriginBitmap.UnlockBits(_bitmapData);
        }
    
        #endregion
    
        public unsafe byte* Begin
        {
            get { return _begin; }
        }
    
        public unsafe byte* this[int x, int y]
        {
            get
            {
                return _begin + y * (_bitmapData.Stride) + x * 3;
            }
        }
    
        public unsafe byte* this[int x, int y, int offset]
        {
            get
            {
                return _begin + y * (_bitmapData.Stride) + x * 3 + offset;
            }
        }
    
        public unsafe void SetColor(int x, int y, Color color)
        {
            byte* p = this[x, y];
            p[0] = color.B;
            p[1] = color.G;
            p[2] = color.R;
        }
    
        public unsafe Color GetColor(int x, int y)
        {
            byte* p = this[x, y];
    
            return new Color
            (
                p[2],
                p[1],
                p[0]
            );
        }
    
        public int Stride
        {
            get { return _bitmapData.Stride; }
        }
    
        public int Width
        {
            get { return _bitmapData.Width; }
        }
    
        public int Height
        {
            get { return _bitmapData.Height; }
        }
    
        public int GetOffset()
        {
            return _bitmapData.Stride - _bitmapData.Width * 3;
        }
    
        public Bitmap OriginBitmap { get; private set; }
    }
