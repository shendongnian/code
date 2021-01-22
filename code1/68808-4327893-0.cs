    var serializer = new DataContractSerializer(tempData.GetType());
    using (var backing = new System.IO.StringWriter())
    using (var writer = new System.Xml.XmlTextWriter(backing))
    {
        serializer.WriteObject(writer, tempData);
        data.XmlData = backing.ToString();
    }
