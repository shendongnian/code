    static public void SerializeToXML(MyWrapper wrapper)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(MyWrapper));
        using (TextWriter textWriter = File.CreateText("test.xml"))
        {
            serializer.Serialize(textWriter, wrapper);
        }
    }
    
    static MyWrapper DeserializeFromXML()
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(MyWrapper));
        using (TextReader textReader = File.OpenText("test.xml"))
        {
            return (MyWrapper)deserializer.Deserialize(textReader);
        }
    }
