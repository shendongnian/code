    string myXMLFile = "SomeFile.xml";
    string fileContent = LoadXML(myXMLFile);
    
    private string LoadXML(string xml)
    {
      XPathDocument xDoc;
      XmlReaderSettings xrs = new XmlReaderSettings();
      // The following line does the "magic".
      xrs.CheckCharacters = false;
    
      using (XmlReader xr = XmlReader.Create(xml, xrs))
      {
        xDoc = new XPathDocument(xr);
      }
    
      if (xDoc != null)
      {
        XPathNavigator xNav = xDoc.CreateNavigator();
        return xNav.OuterXml;
      }
      else
        // Unable to load file
        return null;
    }
