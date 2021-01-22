    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load(_WorkingDir + "Session.xml");
    XmlElement xmlRoot = xmlDoc.DocumentElement;
    foreach(XmlElement e in xmlRoot.GetElementsByTagName("group"))
    {
        // this ensures you are safe to try retrieve the attribute
        if (e.HasAttribute("name")
        { 
            // write out the value of the attribute
            Console.WriteLine(e.GetAttribute("name"));
            // or if you need the specific attribute object
            // you can do it this way
            XmlAttribute attr = e.Attributes["name"];       
            Console.WriteLine(attr.Value);    
        }
    }
