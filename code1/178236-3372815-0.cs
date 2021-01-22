    public static class StringExtensions
    {
        public static string HexToString(this string input)
        {
            return new String(Enumerable.Range(0, input.Length/4)
                                  .Select(idx => (char) int.Parse(input.Substring(idx*4,4),
                                                                  NumberStyles.HexNumber)).ToArray());
        }
    }
