    SortedList sCol = new SortedList();
    
    sCol.Add("bee", "Some extended string matching bee");
    sCol.Add("ay", "value matching ay");
    sCol.Add("cee", "Just a standard cee");
    
    // Go through it backwards.
    for (int i = sCol.Count - 1; i >=0 ; i--)
        Console.WriteLine("sCol[" + i.ToString() + "] = " + sCol.GetByIndex(i));
    
    // Reference By Key
    foreach (string i in sCol.Keys)
        Console.WriteLine("sCol[" + i + "] = " + sCol[i]);
    
    // Enumerate all values
    foreach (string i in sCol.Values)
        Console.WriteLine(i);
