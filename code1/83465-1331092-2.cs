     public String SerializeObject(TestObj object)
     {
            String Serialized = String.Empty;
            MemoryStream memoryStream = new MemoryStream ( );
            XmlSerializer xs = new XmlSerializer(typeof(TestObj));
            XmlTextWriter xmlTextWriter = new XmlTextWriter ( memoryStream, Encoding.UTF8 );
            xs.Serialize (xmlTextWriter, object);
            memoryStream = (MemoryStream) xmlTextWriter.BaseStream;
            Serialized = UTF8Encoding.GetString(memoryStream.ToArray());
            return Serialized;
     }
