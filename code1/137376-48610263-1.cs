    public static object XmlDeserializeObject(string data, Type objType)
        {
            XmlSerializer xmlSer = new XmlSerializer(objType);
            TextReader reader = new StreamReader(data);
            object obj = new object();
            obj = (object)(xmlSer.Deserialize(reader));
            return obj;
        }
