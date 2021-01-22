    IDictionary<string, string> myDict = new Dictionary<string, string>();
    
    myDict.Add("1", "blue");
    myDict.Add("2", "blue");
    myDict.Add("3", "red");
    myDict.Add("4", "green");
    HashSet<string> knownValues = new HashSet<string>();
    Dictionary<string, string> uniqueValues = new Dictionary<string, string>();
    foreach (var pair in myDict)
    {
        if (knownValues.Add(pair.Value))
        {
            uniqueValues.Add(pair.Key, pair.Value);
        }
    }
