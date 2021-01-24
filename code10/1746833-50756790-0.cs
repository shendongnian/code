    XmlSerializer serializer = new XmlSerializer(typeof(Invoice));
    Invoice invoice = null;
    using (StringReader sr = new StringReader(xmlString))
    {
        invoice = serializer.Deserialize(sr) as Invoice;
    }
