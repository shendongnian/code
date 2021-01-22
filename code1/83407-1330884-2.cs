    string[] names = { "Joe", "Jim", "Sam", "Ed", "Sally" };
    
    public IEnumerable<string> GetYieldEnumerable()
    {
        foreach (var name in names)
            yield return name;
    }
    
    public IEnumerable<string> GetList()
    {
        var list = new List<string>();
        foreach (var name in names)
            list.Add(name);
    
        return list;
    }
    
    // we're going to execute the GetYieldEnumerable() method
    // but the foreach statement inside it isn't going to execute
    var yieldNames = GetNamesEnumerable();
    
    // now we're going to execute the GetList() method and
    // the foreach method will execute
    var listNames = GetList();
    
    // now we want to look for a specific name in yieldNames.
    // only the first two iterations of the foreach loop in the 
    // GetYieldEnumeration() method will need to be called to find it.
    if (yieldNames.Contains("Jim")
        Console.WriteLine("Found Jim and only had to loop twice!");
    
    // now we'll look for a specific name in listNames.
    // the entire names collection was already iterated over
    // so we've already paid the initial cost of looping through that collection.
    // now we're going to have to add two more loops to find it in the listNames
    // collection.
    if (listNames.Contains("Jim"))
        Console.WriteLine("Found Jim and had to loop 7 times! (5 for names and 2 for listNames)");
