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
            byte[] b = new byte[8];
            b[0] = Byte0; b[1] = Byte1; b[2] = Byte2; b[3] = Byte3;
            b[4] = Byte4; b[5] = Byte5; b[6] = Byte6; b[7] = Byte7;
            return b;
        }
    }
    // ...
        LongAndBytes lab = new LongAndBytes();
        for (lab.UlongValue = 0; lab.UlongValue != 0xffffffffffffffff; lab.UlongValue++) {
        }
