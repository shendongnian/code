    public static List<IEnumerable<string>>ReadXML(
       string filename, 
       string elementName, 
       IEnumerable<string> attributes, 
       bool searchSubNodes)
    {
       XmlDocument d = new XmlDocument();
       d.Load(filename);
       string xpath = searchSubNodes ? "//" + elementName : "/*/elementName";
       List<IEnumerable<string>> results = new List<IEnumerable<string>>();
       foreach (XmlElement elm in d.SelectNodes(xpath))
       {
          var values = from name in attributes select elm.GetAttribute(name);
          result.Add(values.ToArray());
       }
       return result;
    }
