    var xml = "<Hotspots><Hotspot X=\"-8892.787\" Y=\"-121.9584\" Z=\"82.04719\" /></Hotspots>";
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    foreach (XmlNode item in doc.SelectNodes("/Hotspots/Hotspot"))
    {
        Console.Write(item.Attributes["X"].Value);
        Console.Write(item.Attributes["Y"].Value);
        Console.Write(item.Attributes["Z"].Value);
    }
