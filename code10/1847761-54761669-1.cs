    IDictionary<string, int> bigramsDict = new Dictionary<string, int>();
    for (int i = 0; i < words.Length - 1; i++)
    {
        if (string.IsNullOrWhiteSpace(words[i]))
        {
            continue;
        }
        
        string key = words[i] + " " words[i + 1];
        if (!bigramsDict.ContainsKey(key))
            bigramsDict.Add(key, 1);
        else
            bigramsDict[key]++;    
    }
