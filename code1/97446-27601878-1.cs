    var toRemove = new HashSet<T>();
    foreach(var item in items)
    {
         ...
         if(condition)
              toRemove.Add(item);
    }
    items.RemoveAll(toRemove.Contains);
