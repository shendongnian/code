    using System.Xml;
    //...
    XmlDocument xmldoc = new XmlDocument();
    XmlElement pages = xmldoc.CreateElement("pages");
    XmlElement page = null;
    
    for(int i = 1; i <= 4; i++)
    {
        page = xmldoc.CreateElement("page");
        page.SetAttribute("name", "Page Name " + i);
        page.SetAttribute("url", "/page-" + i + "/");
        pages.AppendChild(page);
    }
    
    xmldoc.AppendChild(xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null));
    xmldoc.AppendChild(pages);
    xmldoc.Save("output.xml");
