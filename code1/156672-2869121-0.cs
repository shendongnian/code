    struct DataStruct
    {
        public short ShortVale;
        public int IntValue;
        public long LongValue;
        public object GetBoxedShortValue() { return ShortVale; }
        public object GetBoxedIntValue() { return IntValue; }
        public object GetBoxedLongValue() { return LongValue; }
    }
