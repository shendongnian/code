    static void Main(string[] args)
    {
        Envelope en = new Envelope();
        en.Items = new EnvelopeBody[1];
        en.Items[0] = new EnvelopeBody();
        en.Items[0].QueryResponse = new QueryResponseFaculties[1];
        en.Items[0].QueryResponse[0] = new QueryResponseFaculties();
        en.Items[0].QueryResponse[0].Name = "John";
    
        XmlSerializer serializer =
         new XmlSerializer(typeof(Envelope));
        TextWriter writer = new StreamWriter("TestOutputFile.xml");
    
        XmlSerlializerNamespaces xsn = new XmlSerializerNamespaces();
        xsn.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
    
        serializer.Serialize(writer, en, xsn);
        writer.Close();
    
        return;
    }
    
    [XmlRoot(Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
    class Envelope
    {
        // ...
    }
