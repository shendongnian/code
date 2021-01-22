    List<string> elementNames = GetElementNames();
    
    newOrder.Add(
      elementNames
        .Select(name => GetElement(name, oldOrder))
        .Where(element => element != null)
        .ToArray()
      );
    
//
    
    public XElement GetElement(string name, XElement source)
    {
      XElement result = null;
      XElement original = source.Elements(name).FirstOrDefault();
      if (original != null)
      {
        result = new XElement(name, (string)original)
      }
      return result;
    }
