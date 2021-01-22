    public bool TryParse<T>(XElement element, string attributeName, TryParser<T> tryParser, out T value)
    {
        if (element.Attribute(attributeName) != null && !string.IsNullOrEmpty(element.Attribute(attributeName).Value))
        {
            string valueString = element.Attribute(attributeName).Value;
            return tryParser(valueString, out value);
        }
        
        return false;
    }
