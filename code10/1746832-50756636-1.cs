    XmlSerializer serializer = new XmlSerializer(typeof(Invoice));
    using (var stringReader = new StringReader(model.XmlDocument))
    {
        Invoice obj = (Invoice)serializer.Deserialize(stringReader);
    }
