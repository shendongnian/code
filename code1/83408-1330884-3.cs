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
    
    var yieldNames = GetNamesEnumerable();
    
    var listNames = GetList();
    
    // now we'll change the source data by renaming "Jim" to "Jimbo"
    names[1] = "Jimbo";
    
    if (yieldNames.Contains("Jimbo")
        Console.WriteLine("Found Jimbo!");
    
    // Because this enumeration was evaluated completely before we changed "Jim"
    // to "Jimbo" it isn't going to be found
    if (listNames.Contains("Jimbo"))
        // this can't be true
    else
       Console.WriteLine("Couldn't find Jimbo, because he wasn't there when I was evaluated.");
