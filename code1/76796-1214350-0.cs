    public static Item FromXElement(XElement element)
    {
        string name = (string) element.Attribute("name");
        string host = (string) element.Attribute("host");
        // etc
        return new Item(name, host, ...);
    }
