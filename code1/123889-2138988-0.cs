    Dictionary<int, int> myDictionary = new Dictionary<int, int>();
    myDictionary.Add(2,4);
    myDictionary.Add(3,5);
    
    int keyToFind = 7;
    if(myDictionary.ContainsKey(keyToFind))
    {
        myValueLookup = myDictionay[keyToFind];
        // do work...
    }
    else
    {
        // the key doesn't exist.
    }
