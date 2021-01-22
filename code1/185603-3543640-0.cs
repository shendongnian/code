    //load the object with the xml file from the web...
    doc.LoadXml(WeatherXML);
    XmlNamespaceManager nsMgr = new XmlNamespaceManager(doc.NameTable);
    nsMgr.AddNamespace("m", "http://www.w3.org/2005/Atom");
    //go to the main node.. 
    XmlNodeList nodes = doc.SelectNodes("m:feed", nsMgr);
    Console.WriteLine(nodes.Count);    // outputs 1
