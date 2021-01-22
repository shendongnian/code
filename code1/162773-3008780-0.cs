    public static IEnumerable<string> SplitByLength(this string s, int length)
    {
        for (int i = 0; i < s.Length; i += length)
        {
            if (i + length <= s.Length)
            {
                yield return s.Substring(i, length);
            }
            else
            {
                yield return s.Substring(i);
            }
        }
    }
