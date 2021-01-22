    // create the XmlDocument and add <root> node
    XmlDocument doc = new XmlDocument();
    doc.AppendChild(doc.CreateElement("root"));
    // dictionary to keep track of <header> nodes
    Dictionary<string, XmlNode> nodesPerColumnA = new Dictionary<string, XmlNode>();
    // Loop through data rows
    foreach (DataRow row in tbl.Rows)
    {
       // extract values for ColumnA and ColumnB as strings
       string columnAValue = row["ColumnA"].ToString();
       string columnBValue = row["ColumnB"].ToString();
       // create a new <item> XmlNode and fill its attribute @Name 
       XmlElement newNode = doc.CreateElement("item");
       XmlAttribute newNodeAttribute = doc.CreateAttribute("name");
       newNodeAttribute.InnerText = columnBValue;
       newNode.Attributes.Append(newNodeAttribute);
       // check if we already have a <header> node for that "ColumnA" value
       if(nodesPerColumnA.ContainsKey(columnAValue))
       {
           // if so - just add <item> below that <header>
           XmlNode parent = nodesPerColumnA[columnAValue];
           parent.AppendChild(newNode);
       }
       else
       {
           // if not - create appropriate <header> node and its @name attribute
           XmlElement header = doc.CreateElement("header");
           XmlAttribute headerAttr = doc.CreateAttribute("name");
           headerAttr.InnerText = columnAValue;
           header.Attributes.Append(headerAttr);
           header.AppendChild(newNode);
           doc.DocumentElement.AppendChild(header);
           
           // store that <header> xmlnode into the dictionary for future use
           nodesPerColumnA.Add(columnAValue, header);
        }
     }
     // check the contents of the XmlDocument at the end
     string xmlContents = doc.InnerXml;
