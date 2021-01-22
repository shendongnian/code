    Monitor.Enter(syncRoot);
    foreach (var item in enumerable)
    {
      Monitor.Exit(syncRoot);
      //Do something with item
      Monitor.Enter(syncRoot);
    }
    Monitor.Exit(syncRoot);
