    public XmlDocument SerializeToXmlDocument(object input)
    {
       XmlSerializer ser = new XmlSerializer(input.GetType(), "http://schemas.yournamespace.com");
       XmlDocument xd = null;
       using(MemoryStream memStm = new MemoryStream())
       {
         ser.Serialize(memStm, input);
         memStm.Position = 0;
         XmlReaderSettings settings = new XmlReaderSettings();
         settings.IgnoreWhitespace = true;
         using(var xtr = XmlReader.Create(memStm, settings))
         {  
            xd = new XmlDocument();
            xd.Load(xtr);
         }
       }
       return xd;
    }
