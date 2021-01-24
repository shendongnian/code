    public static Element Create(
        XmlElement element)
    {            
        if (element.Value == "1")
        {
            return new ClassA(element);
        }
        else if (element.Value == "2")
        {
            return new ClassB(element);
        }
        else if (element.Value == "3")
        {
            return new ClassB(element);
        }
    
        throw new Exception("Could not determine element class");
    }
