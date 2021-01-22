        public static string SerializeToXml(object obj)
        {
            UTF8Encoding encoding = new UTF8Encoding(false);
            var xmlAttributes = new XmlAttributes();
            xmlAttributes.Xmlns = false;
            xmlAttributes.XmlType = new XmlTypeAttribute() { Namespace = "" };
            var xmlAttributeOverrides = new XmlAttributeOverrides();
            var types = obj.GetType().Assembly.GetTypes().Where(t => string.Equals(t.Namespace, obj.GetType().Namespace, StringComparison.Ordinal));
            foreach (var t in types) xmlAttributeOverrides.Add(t, xmlAttributes);
            
            XmlSerializer sr = new XmlSerializer(obj.GetType(), xmlAttributeOverrides);
            MemoryStream memoryStream = new MemoryStream();
            StreamWriter writer = new StreamWriter(memoryStream, encoding);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            // get the stream from the writer
            memoryStream = writer.BaseStream as MemoryStream;
            sr.Serialize(writer, obj, namespaces);
            // apply encoding to the stream 
            return (encoding.GetString(memoryStream.ToArray()).Trim());
        }
