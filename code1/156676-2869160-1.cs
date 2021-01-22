    // Just a simple container that returns values as objects
    struct DataStruct
    {
        public short ShortVale;
        public int IntValue;
        public long LongValue;
        public dynamic GetBoxedShortValue() { return ShortValue; }
        public dynamic GetBoxedIntValue() { return IntValue; }
        public dynamic GetBoxedLongValue() { return LongValue; }
    }
    static void Main( string[] args )
    {
        DataStruct data;
        // Initialize data - any value will do
        data.LongValue = data.IntValue = data.ShortVale = 42;
        DataStruct newData;
        newData.ShortVale = (short)data.GetBoxedShortValue();
        newData.IntValue = (int)data.GetBoxedIntValue();
        newData.LongValue = (long)data.GetBoxedLongValue();
        newData.ShortVale = data.GetBoxedShortValue(); // ok
        newData.IntValue = data.GetBoxedIntValue(); // ok
        newData.LongValue = data.GetBoxedLongValue(); // ok
    }
