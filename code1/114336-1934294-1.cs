        public static string SerializeLINQtoXML<T>(T linqObject)
        {
             // see http://msdn.microsoft.com/en-us/library/bb546184.aspx
             DataContractSerializer dcs = new DataContractSerializer(linqObject.GetType());
  
             StringBuilder sb = new StringBuilder();
             XmlWriter writer = XmlWriter.Create(sb);
             dcs.WriteObject(writer, linqObject);
             writer.Close();
  
             return sb.ToString();
         }
  
         public static T DeserializeLINQfromXML<T>(string input)
         {
             DataContractSerializer dcs = new DataContractSerializer(typeof(T));
  
             TextReader treader = new StringReader(input);
             XmlReader reader = XmlReader.Create(treader);
             T linqObject = (T)dcs.ReadObject(reader, true);
             reader.Close();
  
             return linqObject;
         }
