    static T Deserialize<T>(string xml, XmlSchemaSet schemas)
    {
        //List<XmlSchemaException> exceptions = new List<XmlSchemaException>();
        ValidationEventHandler validationHandler = (s, e) =>
        {
            //you could alternatively catch all the exceptions
            //exceptions.Add(e.Exception);
            throw e.Exception;
        };
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Schemas.Add(schemas);
        settings.ValidationType = ValidationType.Schema;
        settings.ValidationEventHandler += validationHandler;
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (StringReader sr = new StringReader(xml))
            using (XmlReader books = XmlReader.Create(sr, settings))
               return (T)serializer.Deserialize(books);
    }
