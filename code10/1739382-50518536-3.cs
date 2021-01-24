    var root = new RootObject
    {
        AList = new AListObject
        {
            SerializedListObjects = new List<A> { new B(), new C() },
        },
    };
    var serializer = AListSerializerFactory.Instance.CreateSerializer(root.GetType());
    var xml = root.GetXml(serializer);
    var root2 = xml.LoadFromXml<RootObject>(serializer);
