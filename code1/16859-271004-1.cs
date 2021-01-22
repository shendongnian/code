    public static List<ListItem> ToListItems(this Dictionary<T, U> source)
    {
      return source
        .Select(x => new ListItem(x.key.ToString(), x.value.ToString()))
        .ToList();
    }
    
    public static List<V> Convert<V>
    (
      this Dictionary<T, U> source,
      Func<T, U, V> converterFunction
    )
    {
      return source
        .Select(x => converterFunction(x.Key, x.Value))
        .ToList();
    }
