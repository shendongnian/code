    SortedDictionary<double, float> newlogdict = new SortedDictionary<double, float>();
    SortedDictionary<double, float> oldlogdict = new SortedDictionary<double, float>();
    
    float x1 = 3.5F;
    double a = 3.3;
    
    newlogdict.Add(double.NaN, x1);
    oldlogdict.Add(a, x1);
    
    foreach (KeyValuePair<double, float> kvp in newlogdict)
    {
        oldlogdict[kvp.Key] = kvp.Value;      //if key is not found it will be added
    }
    
    Console.WriteLine(newlogdict.Count);
    Console.WriteLine(oldlogdict.Count);
     
