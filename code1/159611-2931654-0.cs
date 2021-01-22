    public static class LinqToStrings
    {
        public static IQueryable<char> LinqReplace(this string source, int startIndex, int length, string replacement)
        {
            var querySource = source.AsQueryable();
            return querySource.LinqReplace(startIndex, length, replacement);
        }
        public static IQueryable<char> LinqReplace(this IQueryable<char> source, int startIndex, int length, string replacement)
        {
            var querySource = source.AsQueryable();
            return querySource.Take(startIndex).Concat(replacement).Concat(querySource.Skip(startIndex + length));
        }
        public static string AsString(this IQueryable<char> source)
        {
            return new string(source.ToArray());
        }
    }
