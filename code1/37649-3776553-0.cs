    public static class BitField
    {
        public static int GetBit(int bitField, int index)
        {
            return (bitField / (int)Math.Pow(10, index)) % 10;
        }
        public static bool GetFlag(int bitField, int index)
        {
            return GetBit(bitField, index) == 1;
        }
    }
