    using System.Xml;
    using System.Xml.Linq;
    
    string[] settingsDataOne;
    string[] settingsDataTwo;
    XmlDocument doc = new XmlDocument();
    //Load XML Doc #1
    doc.Load("settings1.xml");
    XmlNodeList nodeList = doc.SelectNodes("/locations/inner");
    
    foreach (XmlNode node in nodeList)
    {
        var id = node.SelectSingleNode("ID").InnerText;
        var name = node.SelectSingleNode("Name").InnerText;
        settingsDataOne = { id, name };
    }
    //Load XML Doc #2
    doc.Load("settings2.xml")
    nodeList = doc.SelectNodes("/locations/inner");
    
    foreach (XmlNode node in nodeList)
    {
        var id = node.SelectSingleNode("ID").InnerText;
        var name = node.SelectSingleNode("Name").InnerText;
        settingsDataTwo = { id, name };
    }
