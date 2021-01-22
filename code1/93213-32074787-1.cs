    using DomXmlDocument = Windows.Data.Xml.Dom.XmlDocument;
    
        public static class DocumentExtensions
        {
            public static XmlDocument ToXmlDocument(this XDocument xDocument)
            {
                var xmlDocument = new XmlDocument();
                using (var xmlReader = xDocument.CreateReader())
                {
                    xmlDocument.Load(xmlReader);
                }
                return xmlDocument;
            }
    
            public static DomXmlDocument ToDomXmlDocument(this XDocument xDocument)
            {
                var xmlDocument = new DomXmlDocument();
                using (var xmlReader = xDocument.CreateReader())
                {
                    xmlDocument.LoadXml(xmlReader.ReadOuterXml());
                }
                return xmlDocument;
            }
    
            public static XDocument ToXDocument(this XmlDocument xmlDocument)
            {
                using (var memStream = new MemoryStream())
                {
                    using (var w = XmlWriter.Create(memStream))
                    {
                        xmlDocument.WriteContentTo(w);
                    }
                    memStream.Seek(0, SeekOrigin.Begin);
                    using (var r = XmlReader.Create(memStream))
                    {
                        return XDocument.Load(r);
                    }
                }
            }
    
            public static XDocument ToXDocument(this DomXmlDocument xmlDocument)
            {
                using (var memStream = new MemoryStream())
                {
                    using (var w = XmlWriter.Create(memStream))
                    {
                        w.WriteRaw(xmlDocument.GetXml());
                    }
                    memStream.Seek(0, SeekOrigin.Begin);
                    using (var r = XmlReader.Create(memStream))
                    {
                        return XDocument.Load(r);
                    }
                }
            }
        }
