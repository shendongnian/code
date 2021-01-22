    public object GetObjectFromDictionary(string key)
    {
        try
        {
            return MyDictionary[key];
        }
        catch (KeyNotFoundException kex)
        {
            throw new WrappedException("Failed To Find Key: " + key, kex);
        }
    }
