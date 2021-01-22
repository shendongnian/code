    static class IEnumerableExtensions
    {
      public static string Join<T>(this IEnumerable<T> items,
                                   string seperator, string lastSeperator)
      {
        var sep = "";
        return items.Aggregate("", (current, item) =>
          {
            var result = String.Concat(current,
              // not first  OR not last
              current == "" || !items.Last().Equals(item) ? sep : lastSeperator,
              item.ToString());
            sep = seperator;
            return result;
          });
      }
    }
