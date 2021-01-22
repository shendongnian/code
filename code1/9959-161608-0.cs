    private static IDictionary<string, string> ConvertKeysToLowerCase(
        IDictionary<string, string> dictionaries)
    {
        var convertedDictionatry = new Dictionary<string, string>();
        foreach(string key in dictionaries.Keys)
        {
            convertedDictionatry.Add(key.ToLower(), dictionaries[key]);
        }
        return convertedDictionatry;
    }
    
