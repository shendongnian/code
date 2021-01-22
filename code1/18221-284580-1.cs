    XmlElement myElement;
    myXmlReader.Read();
    if (myXmlReader.NodeType == XmlNodeType.Element)
    {
       myElement = doc.CreateElement(myXmlReader.Name);
       myElement.InnerXml = myXmlReader.InnerXml;
    }
