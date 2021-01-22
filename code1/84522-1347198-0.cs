    XDocument xDocument = new XDocument();
    
    for (int i = 0; i < 5; i++)        
    {
      if( XDocument.Element("PlayerCodes") == null)
      {
        XDocument.Add(new XElement("PlayerCodes"));
      }
              
      xDocument.Element("PlayerCodes").Add(new XElement("PlayerCode", i.ToString()));
                
    }
    
    xDocument.Save(@"c:\test.xml");
