    public static class EnumerableStringExtensions
    {
       public static string Concatinate(this IEnumerable<string> strings, string seperater)
       {
          return String.Join(seperater, strings);
       }
    }
