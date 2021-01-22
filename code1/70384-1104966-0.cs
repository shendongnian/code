    List<double> total = new List<double>();
    foreach (AKeyObject key in aDictionary.Keys.ToList())
    {
       for (int i = 0; i < aDictionary[key].Count; i++)
       {
          total[i] += aDictionary[key][i];
       }
    }
