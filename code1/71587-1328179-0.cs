    public struct SomeStruct
    {
        private long data;
        public byte SomeByte { get { return (byte)(data & 0x0FF); } }
        public int SomeInt { get { return (int)((data & 0xFFFFFFFF00) << 8); } }
        public short SomeShort { get { return (short)((data & 0xFFFF0000000000) << 40); } }
        public byte SomeByte2 { get { return (byte)((data & unchecked((long)0xFF00000000000000)) << 56); } }
    }
