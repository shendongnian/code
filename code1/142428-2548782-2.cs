    public string SerializeToXml(object input)
    {
       XmlSerializer ser = new XmlSerializer(input.GetType(), "http://schemas.yournamespace.com");
       string result = string.Empty;
       using(MemoryStream memStm = new MemoryStream())
       {
         ser.Serialize(memStm, input);
         memStm.Position = 0;
         result = new StreamReader(memStm).ReadToEnd();
       } 
       return result;
    } 
