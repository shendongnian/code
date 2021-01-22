    // Get an instance
    var listCache = new MyListCache();
    // Add something
    listCache.MyList.Add(someObject);
    // Enumerate
    foreach(var o in listCache.MyList) {
      Console.WriteLine(o.ToString());
    }  
    // Blow it away
    listCache.ClearList();
