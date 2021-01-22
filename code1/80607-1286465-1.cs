    namespace ExtensionMethods
    {
        public static class Extensions
        {
            /*
             * Since this is marked const, the actual calculation part will happen at
             * compile time rather than at runtime.  This gives you some code clarity
             * without a performance penalty.
             */
            private const uint weekdayBitMask =
                1 << Monday 
                | 1 << Tuesday
                | 1 << Wednesday
                | 1 << Thursday
                | 1 << Friday;
            public static bool isWeekday(this DayOfWeek dayOfWeek)
            {
                return 1 << dayOfWeek & weekdayBitMask > 0;
            }
        }   
    }
