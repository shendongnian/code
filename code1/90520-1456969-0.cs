    MyParentObject parent = new MyParentObject(){ ... };
    
    MyObject obj = new MyObject(){ /*... initialize*/ };
    XmlSerializer ser = new XmlSerializer(typeof(MyObject));
    XmlDocument doc = new XmlDocument();
    using (StringWriter sw = new StringWriter())
    {
        ser.Serialize(sw, obj);
        doc.LoadXml(sw.ToString());
    }
    parent.Any = (XmlElement)doc.DocumentElement;
