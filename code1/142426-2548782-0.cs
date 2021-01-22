    public string SerializeToXml(object input)
    {
       XmlSerializer ser = new XmlSerializer(input.GetType(), "http://schemas.yournamespace.com");
       MemoryStream memStm = new MemoryStream();
       ser.Serialize(memStm, input);
       memStm.Position = 0;
       return new StreamReader(memStm).ReadToEnd();
    } 
