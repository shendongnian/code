    List<string> valueNames = new List<string>();
    List<string> headingNames = new List<string>();
    XmlDocument doc = new XmlDocument();
    doc.Load("data.xml");
    var rootNode = doc.FirstChild;
    var columnsNode = rootNode.FirstChild;
    for (int i = 0; i < columnsNode.ChildNodes.Count; i++)
    {
        XmlNode child = columnsNode.ChildNodes.Item(i);
        for (int j = 0; j < child.Attributes.Count; j++)
        {
            var attribute = child.Attributes.Item(j);
            if (attribute.Name.Equals("XPath"))
            {
                headingNames.Add(attribute.Value);
            }
            else if (attribute.Name.Equals("Name"))
            {
                valueNames.Add(attribute.Value);
            }
        }             
    }
