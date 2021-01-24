    static void Main()
    {
        var g = Guid.NewGuid();
        Console.WriteLine(g);
        var val = new GuidInt64(g);
        var x = val.X;
        var y = val.Y;
        Console.WriteLine(x);
        Console.WriteLine(y);
        var val2 = new GuidInt64(x, y);
        var g2 = val2.Guid;
        Console.WriteLine(g2);
    }
    [StructLayout(LayoutKind.Explicit)]
    struct GuidInt64
    {
        [FieldOffset(0)]
        private Guid _guid;
        [FieldOffset(0)]
        private long _x;
        [FieldOffset(8)]
        private long _y;
        public Guid Guid => _guid;
        public long X => _x;
        public long Y => _y;
        public GuidInt64(Guid guid)
        {
            _x = _y = 0; // to make the compiler happy
            _guid = guid;
        }
        public GuidInt64(long x, long y)
        {
            _guid = Guid.Empty;// to make the compiler happy
            _x = x;
            _y = y;
        }
    }
