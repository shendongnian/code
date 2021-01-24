    public static class ByteExtensions
    {
        public static bool GetBit(this byte b, int bitNumber) =>
            (b & (1 << bitNumber)) != 0;
    }
