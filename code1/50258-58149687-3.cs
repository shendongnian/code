    XmlDocument oDom = new XmlDocument();
    oDom.Load(_sXmlConfig);
    
    string str = oDom.SelectSingleNode("//currentVersion/major").InnerText;
    Int32.TryParse(str, out _nMajor);
    
    str = oDom.SelectSingleNode("//currentVersion/minor").InnerText;
    Int32.TryParse(str, out _nMinor);
    
    str = oDom.SelectSingleNode("//currentVersion/build").InnerText;
    Int32.TryParse(str, out _nBuild); 
    
    _sNewVersionPath = oDom.SelectSingleNode("//path").InnerText;
