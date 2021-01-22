    public static string encode(System.Collections.Generic.List<string> data)
    {
    	var xml = new XmlDocument();
    	xml.AppendChild(xml.CreateElement("data"));
    	foreach (var item in data)
    	{
    		var xmlItem = (XmlElement)xml.DocumentElement.AppendChild(xml.CreateElement("item"));
    		xmlItem.InnerText = item;
    	}
    	return xml.OuterXml;
    }
    
    public static string[] decode(string encoded)
    {
    	var items = new System.Collections.Generic.List<string>();
    	var xml = new XmlDocument();
    	xml.LoadXml(encoded);
    	foreach (XmlElement xmlItem in xml.SelectNodes("/data/item"))
    		items.Add(xmlItem.InnerText);
    	return items.ToArray();
    }
