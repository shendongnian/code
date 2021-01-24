    public static string SerializeStandardObject<T>(T obj, XmlSerializerNamespaces ns)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (StringWriter sw = new StringWriter())
        {
            using (System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(sw))
            {
                serializer.Serialize(writer, obj, (ns == null ? new XmlSerializerNamespaces() : ns));
            }
            return sw.ToString();
        }
    }
