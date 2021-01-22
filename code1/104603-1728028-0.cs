    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(_WorkingDir + "Session.xml");
    XmlElement xmlRoot = xmlDoc.DocumentElement;
    foreach(XmlElement e in xmlRoot.GetElementsByTagName("group"))
    {
        if (e.HasAttribute("name")
        {
            XmlAttribute attr = e.GetAttribute("name");
            Console.WriteLine(attr.Value);
        }
    }
