    public static class CharArrayExtensions
    {
        public static IEnumerable<char> FindInteger(this IEnumerable<char> array)
        {
            foreach (var c in array)
            {
                if(char.IsNumber(c))
                    yield return c;
            }
        }
    }
