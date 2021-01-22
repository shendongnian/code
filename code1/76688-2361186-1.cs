    namespace Utils
    {
        public static class SerializeUtil
        {
            public static void SerializeToFormatter<F>(object obj, string path) where F : IFormatter, new()
            {
                if (obj == null)
                {
                    throw new NullReferenceException("obj Cannot be Null.");
                }
    
                if (obj.GetType().IsSerializable == false)
                {
                    //  throw new 
                }
                IFormatter f = new F();
                SerializeToFormatter(obj, path, f);
            }
    
            public static T DeserializeFromFormatter<T, F>(string path) where F : IFormatter, new()
            {
                T t;
                IFormatter f = new F();
                using (FileStream fs = File.OpenRead(path))
                {
                    t = (T)f.Deserialize(fs);
                }
                return t;
            }
    
            public static void SerializeToXML<T>(string path, object obj)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                using (FileStream fs = File.Create(path))
                {
                    xs.Serialize(fs, obj);
                }
            }
    
            public static T DeserializeFromXML<T>(string path)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                using (FileStream fs = File.OpenRead(path))
                {
                    return (T)xs.Deserialize(fs);
                }
            }
    
            public static T DeserializeFromXml<T>(string xml)
            {
                T result;
    
                var ser = new XmlSerializer(typeof(T));
                using (var tr = new StringReader(xml))
                {
                    result = (T)ser.Deserialize(tr);
                }
                return result;
            }
    
    
            private static void SerializeToFormatter(object obj, string path, IFormatter formatter)
            {
                using (FileStream fs = File.Create(path))
                {
                    formatter.Serialize(fs, obj);
                }
            }
        }
    }
