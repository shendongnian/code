    var copy = myDictionary.ToList();
    foreach (KeyValuePair<string, int> kvp in copy)
    {
        int otherValue;
        if (otherdictionary.TryGetValue(kvp.Key, out otherValue))
        {
            mydictionary[kvp.Key] = otherValue;
        }
        else
        {
            otherdictionary[kvp.Key] = kvp.Value;
        }
    }
