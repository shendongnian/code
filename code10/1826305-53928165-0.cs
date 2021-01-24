    public TextAsset xmlfile;
    
    void SomeMethod()
    {
        var reader = XmlReader.Create(new MemoryStream(xmlfile.bytes));
    }
