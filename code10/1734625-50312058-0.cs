    [XmlRoot(ElementName = ElementName)]
    public class Data : IXmlSerializable
    {
        public const string ElementName = "data";
        XElement element = new XElement((XName)ElementName);
        public string Someattributea
        {
            get { return (string)element.Attribute("someattributea"); }
            set { element.SetAttribute("someattributea", value); }
        }
        public string Someattributeb
        {
            get { return (string)element.Attribute("someattributeb"); }
            set { element.SetAttribute("someattributeb", value); }
        }
        public string Someattributec
        {
            get { return (string)element.Attribute("someattributec"); }
            set { element.SetAttribute("someattributec", value); }
        }
        public string SourceXML
        {
            get
            {
                return element.ToString();
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                element = XElement.Parse(value);
            }
        }
        #region IXmlSerializable Members
        public XmlSchema GetSchema() { return null; }
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            element = (XElement)XNode.ReadFrom(reader);
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach (var attr in element.Attributes())
                writer.WriteAttributeString(attr.Name.LocalName, attr.Name.NamespaceName, attr.Value);
            foreach (var child in element.Elements())
                child.WriteTo(writer);
        }
        #endregion
    }
    public static class XElementExtensions
    {
        public static void SetAttribute(this XElement element, XName attributeName, string value)
        {
            var attr = element.Attribute(attributeName);
            if (value == null)
            {
                if (attr != null)
                    attr.Remove();
            }
            else
            {
                if (attr == null)
                    element.Add(new XAttribute(attributeName, value));
                else
                    attr.Value = value;
            }
        }
    }
