    void Save(SomeClass obj)
    {
        XmlSerializer xs = new XmlSerializer(typeof(SomeClass));
        using (FileStream fs = new FileStream("c:\\test.xml", ...))
        {
            xs.Serialize(fs, obj);
        }
    }
    
    void Load(out SomeClass obj)
    {
        XmlSerializer xs = new XmlSerializer(typeof(SomeClass));
        using (FileStream fs = new FileStream("c:\\test.xml", ...))
        {
            obj = xs.Deserialize(fs);
        }
    }
