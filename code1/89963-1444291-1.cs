    public struct LongAndBytes
    {
        [FieldOffset(0)]
        public ulong UlongValue;
        [FieldOffset(0)]
        public byte Byte0;
        [FieldOffset(1)]
        public byte Byte1;
        [FieldOffset(2)]
        public byte Byte2;
        [FieldOffset(3)]
        public byte Byte3;
        [FieldOffset(4)]
        public byte Byte4;
        [FieldOffset(5)]
        public byte Byte5;
        [FieldOffset(6)]
        public byte Byte6;
        [FieldOffset(7)]
        public byte Byte7;
        public byte[] ToArray()
        {
            return new byte[8] {Byte0, Byte1, Byte2, Byte3, Byte4, Byte5, Byte6, Byte7};
        }
    }
    // ...
        LongAndBytes lab = new LongAndBytes();
        for (lab.UlongValue = 0; lab.UlongValue != 0xffffffffffffffff; lab.UlongValue++) {
        }
