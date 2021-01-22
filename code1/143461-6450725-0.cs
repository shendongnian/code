    public static class StringExtensions
    {
        public static int NthIndexOf(this string s, char c, int n)
        {
            var takeCount = s.TakeWhile(x => (n -= (x == c ? 1 : 0)) > 0).Count();
            return takeCount == s.Length ? -1 : takeCount;
        }
    }
