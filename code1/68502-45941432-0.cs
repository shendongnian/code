    using System.Collections.Concurrent;
    
    var colStates = new ConcurrentDictionary<string,int>();
    colStates["foo"] = 1;
    colStates["bar"] = 2;
    colStates["baz"] = 3;
    
    int OtherCount = 0;
    int TotalCount = 100;
    
    foreach(string key in colStates.Keys)
    {
        double Percent = (double)colStates[key] / TotalCount;
    
        if (Percent < 0.05)
        {
            OtherCount += colStates[key];
            colStates[key] = 0;
        }
    }
    
    colStates.TryAdd("Other", OtherCount);
