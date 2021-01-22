    XmlDocument doc = new XmlDocument();
    doc.Load("yourXmlFile.xml");
    
    XmlNode userNo3 = doc.SelectSingleNode("//Users/User[@ID='3']");
    
    if(userNo3 != null)
    {
       userNo3.ParentNode.RemoveChild(userNo3);
    }
    
    doc.Save("YourNewXmlFile.xml");
