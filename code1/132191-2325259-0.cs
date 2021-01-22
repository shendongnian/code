    public static class stringExtensions
    {
        public static int IntValue(this string s)
        {
            int res = 0;
            if (int.TryParse(s, out res))
                return res;
            return int.MaxValue;
        }
    }
