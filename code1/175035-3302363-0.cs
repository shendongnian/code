        public static string SerializeToXMLString(object ObjectToSerialize)
            {
                //
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("ns", "http://example.uri.here");
                //
                //
                XmlSerializer serializer = new XmlSerializer(ObjectToSerialize.GetType());
                XmlWriterSettings writerSettings = new XmlWriterSettings();
                writerSettings.OmitXmlDeclaration = true;
                StringWriter stringWriter = new StringWriter();
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, writerSettings))
                {
                    serializer.Serialize(xmlWriter, ObjectToSerialize,ns);
                }
                return  stringWriter.ToString();
    }
