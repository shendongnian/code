    public static System.Xml.XmlElement CreateElement(System.Xml.XmlDocument doc, string innerText)
    {
        System.Xml.XmlElement el = doc.CreateElement("name");
        el.InnerText = System.Web.HttpUtility.HtmlEncode(innerText);
        return el;
    }
