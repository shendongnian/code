    <msxsl:script implements-prefix="extension" language="C#">
    <![CDATA[
    
    public XPathNodeIterator GetList(string str, string delimiter)
    {
        string[] items = str.Split(delimiter.ToCharArray(), StringSplitOptions.None);
        XmlDocument doc = new XmlDocument();
        doc.AppendChild(doc.CreateElement("root"));
        using (XmlWriter writer = doc.DocumentElement.CreateNavigator().AppendChild())
        {
            foreach (string item in items)
            {
                writer.WriteElementString("item", item);
            }
        }
        return doc.DocumentElement.CreateNavigator().Select("item");
    }
    </msxsl:script>
