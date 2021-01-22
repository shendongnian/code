    public static class ExtensionMethods
    {
        public static bool InRange(this int val, int lower, int upper)
        {
            return val >= lower && val <= upper;
        }
    }
