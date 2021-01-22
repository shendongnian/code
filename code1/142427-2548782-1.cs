    public XmlDocument SerializeToXmlDocument(object input)
    {
       XmlSerializer ser = new XmlSerializer(input.GetType(), "http://schemas.yournamespace.com");
       MemoryStream memStm = new MemoryStream();
       ser.Serialize(memStm, input);
       memStm.Position = 0;
       var xtr = XmlReader.Create(memStm) { WhitespaceHandling = WhitespaceHandling.None };
       var xd = new XmlDocument();
       xd.Load(xtr);
 
       return xd;
    }
