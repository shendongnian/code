    public static string SerializeAsXml(this Personal personal)
            {
                var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                var settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
    
                //serialize the binding
                string xmlOutput = string.Empty;
                using (StringWriter stream = new StringWriter())
                using (XmlWriter xmlWriter = XmlWriter.Create(stream, settings))
                {
                    XmlSerializer serializer = new XmlSerializer(personal.GetType());
                    serializer.Serialize(xmlWriter, obj, emptyNamepsaces);
                    xmlOutput = stream.ToString();
                }
    
                return xmlOutput;
            }
