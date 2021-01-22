    public static class EnumerableExtensions
    {
        public static bool Contains( this IEnumerable<string> source, string value, StringComparison comparison )
        {
             if (source == null)
             {
                 return false; // nothing is a member of the empty set
             }
             return source.Any( s => string.Equals( s, value, comparison ) );
        }
    }
