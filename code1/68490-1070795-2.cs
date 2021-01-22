    List<string> keys = new List<string>(colStates.Keys);
    foreach(string key in keys)
    {
        double percent = colStates[key] / TotalCount;    
        if (percent < 0.05)
        {
            OtherCount += colStates[key];
            colStates[key] = 0;
        }
    }
