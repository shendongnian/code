    var serializer = new DataContractSerializer(typeof(T));
    using (var backing = new System.IO.StringReader(data.XmlData))
    using (var reader = new System.Xml.XmlTextReader(backing))
    {
        return serializer.ReadObject(reader) as T;
    }
