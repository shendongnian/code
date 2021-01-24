    private static void RemoveEmptyNamespace(XElement element)
    {
        XAttribute attr = element.Attribute("xmlns");
        if (attr != null && string.IsNullOrEmpty(attr.Value))
            attr.Remove();
        foreach (XElement el in element.Elements())
            RemoveEmptyNamespace(el);
    }
