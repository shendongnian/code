    public static string ObjectToXml<T>(T objectToSerialise)
    {
        StringWriter Output = new StringWriter(new StringBuilder());
        XmlSerializer xs = new XmlSerializer(objectToSerialise.GetType());
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("MyNs", "http://www.someXmlNamespace/namespace1"); // add as many or few as you need
        xs.Serialize(Output, objectToSerialise, ns);
        return Output.ToString();
    }
