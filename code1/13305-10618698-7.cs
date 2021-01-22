    public static class EnumerableStringExtensions
    {
       public static string Concatenate(this IEnumerable<string> strings, string separator)
       {
          return String.Join(separator, strings);
       }
    }
