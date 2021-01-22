    public static string Serialize<T>(T obj)
    {
        StringBuilder sb = new StringBuilder();
        DataContractSerializer ser = new DataContractSerializer(typeof(T));
        ser.WriteObject(XmlWriter.Create(sb), obj);
        return sb.ToString();
    }
