    private static void AddStringEmptyAfterEveryElement(XDocument documentElement)
    {
        AddStringEmptyAfterElement(documentElement.Root);
    }
    private static void AddStringEmptyAfterElement(XElement rootElement)
    {
        foreach ( XElement element in rootElement.Descendants() ) {
            if ( element.HasElements ) {
                AddStringEmptyAfterElement(element);
            }
            element.Add(String.Empty);
        }
    }
