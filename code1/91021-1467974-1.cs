    public static IEnumerable<TItem> MakeEnumerable<TSource,TItem>(
      this TSource source, 
      Func<TSource,int,TItem> getItem,
      Func<TSource,int> getCount) {
      var count = getCount(source);
      for ( var i = 0; i < count; i++) {
        yield return getItem(source,i);
      }
    }
    
    ...
    var devices = GetTheDevicesInstance();
    var e = devices.MakeEnumerable((s,i) => s[i], (s) => s.Count);
