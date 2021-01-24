    static void Main()
    {
        var element = XElement.Load(@"C:\Users\user\Downloads\CollectionOfObjects.xml");
        ElementsToAttributes(element);
        element.Save(@"C:\Users\user\Downloads\CollectionOfObjects-copy.xml");
    }
    static void ElementsToAttributes(XElement element)
    {
        foreach(var el in element.Elements().ToList())
        {
            if(!el.HasAttributes && !el.HasElements)
            {
                var attribute = new XAttribute(el.Name, el.Value);
                element.Add(attribute);
                el.Remove();
            }
            else
                ElementsToAttributes(el);
        }
    } 
