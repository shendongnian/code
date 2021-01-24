    public static class ElementFactory
    {
        public static Element Create(
            XmlElement element)
        {            
            if (element.Value == "1")
            {
                return new ClassA();
            }
            else if (element.Value == "2")
            {
                return new ClassB();
            }
            else if (element.Value == "3")
            {
                return new ClassB();
            }
    
            throw new Exception("Could not determine element class");
        }
    }
