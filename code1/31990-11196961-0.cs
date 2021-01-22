    var serializer = new XmlSerializer(typeof(TheObjectType));
    StringWriter serialized1 = new StringWriter(), serialized2 = new StringWriter();
    serializer.Serialize(serialized1, obj1);
    serializer.Serialize(serialized2, obj2);
    bool areEqual = serialized1.ToString() == serialized2.ToString();
