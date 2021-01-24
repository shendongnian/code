    public static LegacyBusinessObject Merge(Dictionary<string, LegacyBusinessObject> objects)
    {
        var result = new LegacyBusinessObject();
        foreach (var prop in typeof(LegacyBusinessObject).GetFields())
        {
            var propDictionaryNew = (IDictionary)prop.GetValue(result);
            foreach (var dict in objects)
            {
                var propDictionaryOld = (IDictionary)prop.GetValue(dict.Value);
                foreach (DictionaryEntry de in propDictionaryOld)
                {
                    propDictionaryNew[de.Key] = de.Value;
                    // Or: 
                    //((IDictionary)result).Add(de.Key, de.Value);
                    // But be aware of exceptions if de.Key is present in multiple dictionaries
                }
            }
        }
        return result;
    }
