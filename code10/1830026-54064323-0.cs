    public static class ByteExtensions
    {
        public static bool GetBit(this byte b, int bitNumber) =>
            Math.Abs((b & (1 << bitNumber)) / Math.Pow(2, bitNumber)) > 0;
    }
