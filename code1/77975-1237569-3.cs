    MyData md = new MyData { MyDateTime = null };
    XmlSerializer ser = new XmlSerializer(typeof(MyData));
    using (var writer = XmlWriter.Create(@"d:\temp\test.xml"))
    {
        ser.Serialize(writer, md);
    }
    
    using (var reader = XmlReader.Create(@"d:\temp\test.xml"))
    {
        md = (MyData)ser.Deserialize(reader);
        WL(md.MyDateTime.HasValue);
    }
