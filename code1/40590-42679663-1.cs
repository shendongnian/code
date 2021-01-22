    public string GetValue(string propertyName, SearchResult result)
    {
        foreach (var property in result.Properties)
        {
            if (((DictionaryEntry)property).Key.ToString() == propertyName)
            {
                return ((ResultPropertyValueCollection)((DictionaryEntry)property).Value)[0].ToString();
            }
        }
        return null;
    }
