    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml); // your XML
    XmlNodeList nodes = doc.DocumentElement.SelectNodes("/"); // Your XML Nodes
    Dictionary<string, object> dic = new Dictionary<string, object>(); // your 
    dictionary Key, Value
    foreach (XmlNode n in nodes) { 
        dic.Add(n.Name, n.InnerText); // name is your tag and InnerText or InnerXML is your value
    }
    json = JsonConvert.SerializeObject(dic);
