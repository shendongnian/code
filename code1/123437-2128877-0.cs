    static public void SerializeToXML(MyWrapper wrapper)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<MyWrapper>));
        using (TextWriter textWriter = File.CreateText("test.xml"))
        {
            // Create single-element list
            serializer.Serialize(textWriter, new List<MyWrapper>{wrapper});
        }
    }
    static List<MyWrapper> DeserializeFromXML()
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(List<MyWrapper>));
        using (TextReader textReader = File.OpenText("test.xml"))
        {
            return (List<MyWrapper>)deserializer.Deserialize(textReader);
        }
    }
