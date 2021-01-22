    public static string SerializeToXml(T obj)
    {
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    
        ns.Add("","");
    
        StringWriter Output = new StringWriter(new StringBuilder());
        XmlSerializer ser = new XmlSerializer(obj.GetType);
        ser.Serialize(Output, obj, ns);
    
        return Output.ToString();
    }
