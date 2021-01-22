    public int GetInt(string id, string key)
    {
        int value;
        Dictionary<string, int> cache;
        if (cast_cache.TryGetValue(id, out cache) 
              && cache.TryGetValue(key, out value))
        {
            return value;
        }
        if (int.TryParse(map[id][key], out value))
        {
            this.AddToCache(id, key, value);
            return value;
        }
        throw new InvalidOperationException("Trying to obtain a non-integer value with GetInt().");
    }
