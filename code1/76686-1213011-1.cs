    List<object> list = new List<object>();
    list.Add(new Foo());
    list.Add(new Bar());
    
    XmlSerializer xs = new XmlSerializer(typeof(object), new Type[] {typeof(Foo), typeof(Bar)});
    using (StreamWriter streamWriter = System.IO.File.CreateText(fileName))
    {
        xs.Serialize(streamWriter, list);
    }
