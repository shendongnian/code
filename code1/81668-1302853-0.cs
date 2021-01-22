    if (!cache.Contains(key))
    {
        lock(mylockobj)
        {
            if (!cache.Contains(key))
            {
                 cache.Add(key, key)
            }
        }
    }
