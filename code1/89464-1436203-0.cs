    public static class ExtensionMethods
    {
        public int LowWord(this int number)
        { return number & 0x0000FFFF; }
        public int LowWord(this int number, int newValue)
        { return (number & 0xFFFF0000) + (newValue & 0x0000FFFF); }
        public int HighWord(this int number)
        { return number & 0xFFFF0000; }
        public int HighWord(this int number, int newValue)
        { return (number & 0x0000FFFF) + (newValue << 16); }
    }
