    List<string> keys = new List<string>(colStates.Keys);
    foreach(string key in keys)
    {
    
        double  Percent = colStates[key] / TotalCount;
    
        if (Percent < 0.05)
        {
            OtherCount += colStates[key];
            colStates[key] = 0;
        }
    }
