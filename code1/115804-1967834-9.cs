    // myDictDict is Dictionary<string, Dictionary<string, string>>
    Dictionary<string, string> myDict;
    string key = "hello";
    if (!myDictDict.TryGetValue(key, out myDict)) {
        myDict = new Dictionary<string, string>();
        myDictDict.Add(key, myDict);
    }
    myDict.Add("tom", "cat");
