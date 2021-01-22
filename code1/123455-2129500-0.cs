    static public MemoryStream SerializeToXML(MyWrapper list)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(MyWrapper));
        MemoryStream stream = new MemoryStream();
        XmlWriter writer = XmlWriter.Create(stream);
        writer.WriteStartDocument();
        writer.WriteComment("Product XY Version 1.0.0.0");
        serializer.Serialize(writer, course);
        writer.WriteEndDocument();
        writer.Flush();
        return stream;
    }
