       public class XmlSerializerHelper
      {
        public Type _type;
        public XmlSerializerHelper(Type t)
        {
            _type = t;
        }
        public void Save(string path,object obj)
        {
            using (XmlSerializer serializer = new XmlSerializer(_type) ) 
            {
              TextWriter textWriter = new StreamWriter(path);
              serializer.Serialize(textWriter, obj);
            }   
 
        }
        public object Read(string path)
        {
            object result;
            using (XmlSerializer deserializer = new XmlSerializer(_type)) 
            {
              TextReader textReader = new StreamReader(path);
              result =deserializer.Deserialize(textReader);
            } 
            return result;
        }
    }
