    [StructLayout(LayoutKind.Explicit)]
    struct BytetoDoubleConverter
    {
        [FieldOffset(0)]
        public Byte[] Bytes;
        [FieldOffset(0)]
        public Double[] Doubles;
    }
    //...
    static Double Sum(byte[] data)
    {
        BytetoDoubleConverter convert = new BytetoDoubleConverter { Bytes = data };
        Double result = 0;
        for (int i = 0; i < convert.Doubles.Length / sizeof(Double); i++)
        {
            result += convert.Doubles[i];
        }
        return result;
    }
