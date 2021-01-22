    List<string> keys = new List<string>(colStates.Keys);
    for(int i = 0; i < keys.Count; i++)
    {
        string key = keys[i];
        double  Percent = colStates[key] / TotalCount;
        if (Percent < 0.05)    
        {        
            OtherCount += colStates[key];
            colStates[key] = 0;    
        }
    }
