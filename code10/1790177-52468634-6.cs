    public static class StringExtensions
    {
        public static List<string> PowerSet(this string str)
        {
            var n = str.Length;
            var powerSetCount = 1 << n;
            var result = new List<string>();
            for (var setMask = 0; setMask < powerSetCount; setMask++)
            {
                var subset = new StringBuilder();
                for (var i = 0; i < n; i++)
                {
                    if ((setMask & (1 << i)) > 0)
                    {
                        subset.Append(str[i]);
                    }
                }
                result.Add(subset.ToString());
            }
            return result;
        }
    }
