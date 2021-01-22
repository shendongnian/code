    static void AddToElement(XElement outerParent, string innerParent, string name, object value)
    {
        XElement inner = outerParent.Element(innerParent);
        if (inner == null)
        {
            inner = new XElement(innerParent);
            outerParent.Add(inner);
        }
        inner.Add(new XElement(name, value));
    }
