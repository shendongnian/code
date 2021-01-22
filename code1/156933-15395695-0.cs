    public static XElement WithDefaultXmlNamespace(this XElement xelem, XNamespace xmlns)
    {
        XName name;
        if (xelem.Name.NamespaceName == string.Empty)
            name = xmlns + xelem.Name.LocalName;
        else
            name = xelem.Name;
        if (xelem.Elements().Count() == 0)
        {
            return new XElement(name, xelem.Value);
        }
        return new XElement(name,
                        from e in xelem.Elements()
                        select e.WithDefaultXmlNamespace(xmlns));
    }
