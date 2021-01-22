    List<string> keysToNuke = new List<string>();
    foreach(string key in colStates.Keys)
    {
        double percent = colStates[key] / TotalCount;    
        if (percent < 0.05)
        {
            OtherCount += colStates[key];
            keysToNuke.Add(key);
        }
    }
    foreach (string key in keysToNuke)
    {
        colStates[key] = 0;
    }
