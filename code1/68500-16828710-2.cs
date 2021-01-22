    using System.Linq;
    foreach(string key in colStates.Keys.ToList())
    {
      double  Percent = colStates[key] / TotalCount;
    
        if (Percent < 0.05)
        {
            OtherCount += colStates[key];
            colStates[key] = 0;
        }
    }
