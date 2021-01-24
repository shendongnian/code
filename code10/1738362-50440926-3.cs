    public Invoices ParseRecords(Stream stream)
    {
        Invoices invoices;
        try
        {
            stream.Position = 0;
            XmlSerializer serializer = new XmlSerializer(typeof(Invoices);
            invoices = (Invoices)serializer.Deserialize(stream);
        }
        catch (Exception ex)
        {
            log.Error(ex);
        }
        return invoices;
    }
