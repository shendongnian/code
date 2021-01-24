    [StructLayout(LayoutKind.Explicit)]
    struct Int32ToBytes
    {
        [FieldOffset(0)]
        public int Int32;
        [FieldOffset(0)]
        public uint Uint32;
        [FieldOffset(0)]
        public byte Byte0;
        [FieldOffset(1)]
        public byte Byte1;
        [FieldOffset(2)]
        public byte Byte2;
        [FieldOffset(3)]
        public byte Byte3;
    }
    public struct Int24
    {
        public byte Byte0;
        public byte Byte1;
        public byte Byte2;
    }
