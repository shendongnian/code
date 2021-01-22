     public static byte[] SerializeByteByType(object objectToSerialize, Type type)
        {
            XmlWriterSettings xmlSetting = new XmlWriterSettings()
            {
                NewLineOnAttributes = false,
                OmitXmlDeclaration = true,
                Indent = false,
                NewLineHandling = NewLineHandling.None,
                Encoding = Encoding.UTF8,
                NamespaceHandling = NamespaceHandling.OmitDuplicates
            };
            using (MemoryStream stm = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(stm, xmlSetting))
                {
                    var xmlAttributes = new XmlAttributes();
                    var xmlAttributeOverrides = new XmlAttributeOverrides();
                    xmlAttributes.Xmlns = false;
                    xmlAttributes.XmlType = new XmlTypeAttribute() { Namespace = "" };
                    xmlAttributeOverrides.Add(type, xmlAttributes);
                    XmlSerializer serializer = new XmlSerializer(type, xmlAttributeOverrides);
                    //Use the following to serialize without namespaces
                    XmlSerializerNamespaces xmlSrzNamespace = new XmlSerializerNamespaces();
                    xmlSrzNamespace.Add("", "");
                    serializer.Serialize(writer, objectToSerialize, xmlSrzNamespace);
                    stm.Flush();
                    stm.Position = 0;
                }
                return stm.ToArray();
            }
        }         
