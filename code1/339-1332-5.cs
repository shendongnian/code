    System.Collections.Generic.Dictionary<string, int> myDict = new Dictionary<string, int>();
        myDict.Add("one", 1);
        myDict.Add("four", 4);
        myDict.Add("two", 2);
        myDict.Add("three", 3);
        var sortedDict = (from entry in myDict orderby entry.Value ascending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
