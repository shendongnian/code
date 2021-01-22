    collectionXML
        .Elements("sets")
        .Elements("set")
        .Select(c => c)
        .Each(x => SetValue(x));
    
    void SetValue(XElement element)
    {
        myString = element.GetElementValue("title");
    }
    
    // Each extension method (needs to be in a static class)
    public static void Each<T>(this IEnumerable<T> items, Action<T> action)
    {
        foreach (var item in items) action(item);
    }
