    public string XmlSerializeObject(object obj)
    {
        string xmlStr = String.Empty;
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = false;
        settings.OmitXmlDeclaration = true;
        settings.NewLineChars = String.Empty;
        settings.NewLineHandling = NewLineHandling.None;
    
        using (StringWriter stringWriter = new StringWriter())
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                XmlSerializer serializer = new XmlSerializer( obj.GetType());
                serializer.Serialize(xmlWriter, obj);
                xmlStr = stringWriter.ToString();
                xmlWriter.Close();
            }
        }
        return xmlStr.ToString(); 
    }
        
    public object XmlDeserializeObject(string data, Type objType)
    {
        XmlSerializer xmlSer = new XmlSerializer(objType);
        StringReader reader = new StringReader(data);
        
        object obj = new object();
        obj = (object)(xmlSer.Deserialize(reader));
        return obj;
    }
   
