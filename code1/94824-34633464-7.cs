    var ints = new [] { 1, 2, 3, 4, 5 };
    var cachedEnumerable = new CachedEnumerable<int>(ints); 
    foreach (var x in cachedEnumerable)
    {
        foreach (var y in cachedEnumerable)
        {
            //Do something
        }
    }
