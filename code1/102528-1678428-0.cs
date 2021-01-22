    using System.Xml;
    ...
    XmlDocument doc = new XmlDocument();
    XmlNode docNode = doc.CreateXmlDeclaration("1.0", "utf-8", null);
    doc.AppendChild(docNode);
    XmlNode source = doc.CreateElement("source");
    
    XmlNode publisher = doc.CreateElement("publisher");
    publisher.InnerText = "Super X Job Site";
    source.AppendChild(publisher);
    
    XmlNode publisherUrl = doc.CreateElement("publisherurl");
    publisherUrl.InnerText = "http://www.superxjobsite.com";
    source.AppendChild(publisherUrl);
    
    foreach(Job job in Jobs)
    {
    	XmlNode jobNode = doc.CreateElement("job");
    	...
    	source.AppendChild(jobNode);
    
    }
    
    doc.AppendChild(source);
