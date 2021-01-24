    public static Uri GetUri(this Dictionary<string, string> source, string key)
    {
        if (!source.TryGetValue(key, out string value))
            throw new ConfigurationException($"{key} not found");
    
        if (!Uri.TryCreate(value, UriKind.Absolute, out Uri result))
            throw new ConfigurationException($"{key} is not a valid uri: {value}");
    
        return result;
    }
