    XmlReader xmlReader = XmlReader.Create(fileName);
    List<string> names = new List<string>(); 
    
    while (xmlReader.Read())
    {
       //keep reading until we see your element
       if (xmlReader.Name.Equals("Keyword") && (xmlReader.NodeType == XmlNodeType.Element))
       {
         // get attribute from the Xml element here
         string name = xmlReader.GetAttribute("name");
         // --> now **add to collection** - or whatever
         names.Add(name);
       }
    }
