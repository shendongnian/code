    public string ConvertToXML(object obj)
    {
        MemoryStream ms = new MemoryStream();
        using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(ms, Encoding.UTF8, true))
        {
             writer.WriteStartDocument();
             if (obj is IMyCollection)
             {
                  IMyCollection collection = (IMyCollection)obj;
                  writer.WriteStartElement("response");
                  writer.WriteElementString("startIndex","0");
                  var responses = collection.getEntry();
                  foreach (var item in responses)
                  {
                       writer.WriteStartElement("entry");
                       DataContractSerializer ser = new DataContractSerializer(item.GetType());                
                       ser.WriteObject(writer, item);
                       writer.WriteEndElement();
                  }
                  writer.WriteEndElement();
            }
            writer.Flush();
            return Encoding.UTF8.GetString(ms.ToArray());
    }
