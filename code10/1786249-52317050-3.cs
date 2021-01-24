    public static class Extensions
    {
        public static bool IsInRange(this string value, string start, string end, 
            bool ignoreCase = false)
        {
            if (value == null) return start == null;
            if (end == null) return false;
            return string.Compare(value, start, ignoreCase) > -1 &&
                   string.Compare(value, end, ignoreCase) < 1;
        }
    }
