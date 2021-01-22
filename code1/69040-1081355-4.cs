     public class XmlSerializerHelper<T>
        {
            public Type _type;
    
            public XmlSerializerHelper()
            {
                _type = typeof(T);
            }
    
    
            public void Save(string path, object obj)
            {
                using (TextWriter textWriter = new StreamWriter(path)) 
                {
                    XmlSerializer serializer = new XmlSerializer(_type);
                  serializer.Serialize(textWriter, obj);
                }   
     
            }
    
            public object Read(string path)
            {
                object result;
                using (TextReader textReader = new StreamReader(path)) 
                {
                    XmlSerializer deserializer = new XmlSerializer(_type);
                  result =deserializer.Deserialize(textReader);
                } 
                return result;
    
            }
        }
