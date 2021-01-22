    using System.Xml;
    using System.Xml.Linq;
       #region Extention Method
        public static XElement ToXElement(this XmlElement element)
        {
            return XElement.Parse(element.OuterXml);
        }
        public static XmlElement ToXmlElement(this XElement element)
        {
            var doc = new XmlDocument();
            doc.LoadXml(element.ToString());
            return doc.DocumentElement;            
        }
        #endregion
