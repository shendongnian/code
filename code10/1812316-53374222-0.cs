    Root root = new Root();
    root.Objects.Add(new GameObject { Property1 = 2 });
    root.Objects.Add(new SampleObject { Property1 = 5, Property2 = 12 });
    XmlSerializer ser = new XmlSerializer(typeof(Root), new Type[] { typeof(SampleObject) });
    using (MemoryStream stream = new MemoryStream())
    {
        ser.Serialize(stream, root);
        stream.Position = 0;
        Root deserialized = (Root)ser.Deserialize(stream);
    }
