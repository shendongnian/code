    class BitControl : Control
    {
        [TypeConverter(typeof(UInt64HexConverter))]
        public ulong Mask { get; set; }
    }
