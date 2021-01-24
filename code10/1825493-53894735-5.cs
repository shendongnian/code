    public static string Serialize(object dataToSerialize)
    {
        if (dataToSerialize == null) return null;
        using (StringWriter stringWriter = new StringWriter())
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("p", "http://www.dhl.com");
            namespaces.Add("p1", "http://www.dhl.com/datatypes");
            namespaces.Add("p2", "http://www.dhl.com/DCTRequestdatatypes");
            namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            var serializer = new XmlSerializer(dataToSerialize.GetType());
            serializer.Serialize(stringWriter, dataToSerialize, namespaces);
            return stringWriter.ToString();
        }        
    }
