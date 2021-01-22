    public static XElement FindOrAdd(this XContainer container, XName name)
    {
        XElement ret = container.Element(name);
        if (ret == null)
        {
            ret = new XElement(name);
            container.Add(ret);
        }
        return ret;
    }
