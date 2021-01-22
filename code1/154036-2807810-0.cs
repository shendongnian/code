    public static class StringExtensions
    {
        public static bool In(this string input, params string[] test)
        {
            foreach (var item in test)
                if (item.CompareTo(input) == 0)
                    return true;
            return false;
        }
    }
