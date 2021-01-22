    object GetValueObject(string type, string value)
    {
      switch (type)
      {
        case "System.Boolean":
          return Boolean.Parse(value);
        case "System.Int32":
          return Int32.Parse(value);
        ...
        default:
          return value;
      }
    }  
    var type = publishNode.Attributes["Type"].value;
    var value = publishNode.InnerText;
    var valueObject = GetValueObject(type, value);
  
