    private T GetValue<T>(string _attributeValue) where T : struct
    {
        return default(T);
    }
    public float GetFloatValue(string _attributeValue)
    {
        return GetValue<float>(_attributeValue);
    }
    public int GetIntValue(string _attributeValue)
    {
        return GetValue<int>(_attributeValue);
    }
