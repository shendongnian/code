    public T TryGet<T>(string argumentName)
    {
        if (!_internalDictionary.ContainsKey(argumentName))
        {
            return default(T);
        }
        return (T)_internalDictionary[argumentName];
    }
