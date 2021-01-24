    [StructLayout(LayoutKind.Explicit)]
    struct GuidConverter
    {
        [FieldOffset(0)]
        public decimal Decimal;
        [FieldOffset(0)]
        public Guid Guid;
        [FieldOffset(0)]
        public long Long1;
        [FieldOffset(8)]
        public long Long2;
    }
    private static GuidConverter _converter;
    public static (long, long) FastGuidToLongs(this Guid guid)
    {
        _converter.Guid = guid;
        return (_converter.Long1, _converter.Long2);
    }
    public static Guid FastLongsToGuid(long a, long b)
    {
        _converter.Long1 = a;
        _converter.Long2 = b;
        return _converter.Guid;
    }
