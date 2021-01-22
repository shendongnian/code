    // dictionary to serialize to string
    Dictionary<string, object> myDict = new Dictionary<string, object>();
    // add items to the dictionary...
    myDict.Add(...);
    // serialization is straight-forward
    string serialized = myDict.Serialize();
    ...
    // deserialization is just as simple
    Dictionary<string, object> myDictCopy = 
        serialized.Deserialize<Dictionary<string,object>>();
