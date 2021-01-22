    static IEnumerable<XElement> ElementAndChildren(this XElement parent, string name, string childName) 
    {
        var element = parent.Element(name);
        if (element == null)
        {
            return Enumerable.Empty<XElement>();
        }
        return element.Elements(childName);
    }
    ...
    var myItems = from myNode in Nodes.ElementAndChildren("MYTAG1","MYTAG2")
                           select new EPTableItem
                           {
                           //    Assign stuff here                            
                           };
