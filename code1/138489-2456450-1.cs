    public static int TryGetInt(this IDictionary dict, string key)
    {
        int val;
        if (dict.Contains(key))
        {
            if (int.TryParse((string)dict[key], out val))
                return val;
            else
                throw new Exception("Value is not a valid integer.");    
        }
    
        throw new Exception("Key not found.");
    }
