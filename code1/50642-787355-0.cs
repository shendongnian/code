    [Flags]
    public enum MyEnum
    {
        FlagA,
        FlagB,
        // etc.
    }
    
    public static class MyEnumExt
    {
        public static bool HasFlags(this MyEnum item, MyEnum query)
        {
            return ((item & query) == query);
        }
    }
