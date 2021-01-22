    public static IEnumerable<IGrouping<int, T>> GroupByContiguous(
      this IEnumerable<T> source,
      Func<T, int> keySelector
    )
    {
       int keyGroup = Int32.MinValue;
       int currentGroupValue = Int32.MinValue;
       return source
         .Select(t => new {obj = t, key = keySelector(t))
         .OrderBy(x => x.key)
         .GroupBy(x => {
           if (currentGroupValue + 1 < x.key)
           {
             keyGroup = x.key;
           }
           currentGroupValue = x.key;
           return keyGroup;
         }, x => x.obj);
    }
