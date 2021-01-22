    public static IEnumerable<T> GetRange<T>(this IEnumerable<T> enumerable, string range) {
      var arr = range.Split(':');
      var start = Int32.Parse(arr[0]);
      if ( arr[1] == "*" ) {
        return enmuerable.Skip(start);
      } else {
        var end = Int32.Parse(arr[1]);
        return enumerable.Skip(start).Take(end-start);
      }
    }
