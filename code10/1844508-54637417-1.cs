    string message = string.Empty;
    MyMessageTpe obj = new MyMessageTpe() { Age = 20 };
    XmlSerializer xmlSerialization = new XmlSerializer(typeof(MyMessageTpe));
    Stream str = new MemoryStream();
    TextWriter strWriter = new StreamWriter(str);
    
    xmlSerialization.Serialize(strWriter, obj);
