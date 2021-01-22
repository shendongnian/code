    public static T Deserialise<T>(string json)
    {
        T obj = Activator.CreateInstance<T>();
        using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
        {
            DataContractJsonSerializer serialiser = new DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms); // <== Your missing line
            return obj;
        } 
    }
