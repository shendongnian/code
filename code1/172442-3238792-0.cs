    public static string DataContractSerializeObject<T>(T objectToSerialize)
    {
        MemoryStream memStm = new MemoryStream();
        var serializer = new DataContractSerializer(typeof(T));
        serializer.WriteObject(memStm, objectToSerialize);
        memStm.Seek(SeekOrigin.Begin, 0);
        string result = new StreamReader(memStm).ReadToEnd();
        return result;
    }
