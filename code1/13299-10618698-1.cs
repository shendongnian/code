    public static class EnumerableStringExtensions
    {
       public static string Concatinate(this IEnumerable<string> strings, string seperator)
       {
          return String.Join(seperator, strings);
       }
    }
