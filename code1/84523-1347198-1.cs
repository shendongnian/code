    XDocument xDocument = new XDocument();
    XElement playerCodes = new XElement("PlayerCodes");
    xDocument.Add(playerCodes);
    
    for (int i = 0; i < 5; i++)        
    {
        playerCodes.Add(new XElement("PlayerCode", i.ToString()));
    }
    
    xDocument.Save(@"c:\test.xml");
