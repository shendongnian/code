    public GeneratedClassFromXSD GetObjectFromXML()
    {
        var settings = new XmlReaderSettings();
        var obj = new GeneratedClassFromXSD();
        var reader = XmlReader.Create(urlToService, settings);
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(GeneratedClassFromXSD));
        obj = (GeneratedClassFromXSD)serializer.Deserialize(reader);
     
        reader.Close();
        return obj;
    }
