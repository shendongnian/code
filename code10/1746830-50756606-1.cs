    Invoice invoice;
    XmlSerializer serializer = new XmlSerializer(typeof(Invoice));
    using (var reader = new StringReader(model.XmlDocument))
    {
        invoice = (Invoice)serializer.Deserialize(reader);
    }
