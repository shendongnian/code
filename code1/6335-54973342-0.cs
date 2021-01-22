    using System;
    using T = MyNamespace.MyFlags;
    namespace MyNamespace
    {
        [Flags]
        public enum MyFlags
        {
            None = 0,
            Flag1 = 1,
            Flag2 = 2
        }
        static class MyFlagsEx
        {
            public static bool Has(this T type, T value)
            {
                return (type & value) == value;
            }
            public static bool Is(this T type, T value)
            {
                return type == value;
            }
            public static T Add(this T type, T value)
            {
                return type | value;
            }
            public static T Remove(this T type, T value)
            {
                return type & ~value;
            }
        }
    }
