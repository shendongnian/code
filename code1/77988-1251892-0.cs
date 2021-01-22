    public XmlDocument GetEntityXml<T>()
    {
        XmlAttributeOverrides overrides = new XmlAttributeOverrides();
        XmlAttributes attr = new XmlAttributes();
        attr.XmlRoot = new XmlRootAttribute("TheRootElementName");
        overrides.Add(typeof(List<T>), attr);
        XmlDocument xmlDoc = new XmlDocument();
        XPathNavigator nav = xmlDoc.CreateNavigator();
        using (XmlWriter writer = nav.AppendChild())
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<T>), overrides);
            List<T> parameters = GetAll<T>();
            ser.Serialize(writer, parameters);
        }
        return xmlDoc;
    }
