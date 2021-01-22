    public static string Serialize<T>(T obj)
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
        using (MemoryStream ms = new MemoryStream())
        {
            serializer.WriteObject(ms, obj);
            return Encoding.Default.GetString(ms.ToArray());
        }
    }
