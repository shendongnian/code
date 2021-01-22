    public static string DataContractSerializeObject<T>(T objectToSerialize)
    {
        using(MemoryStream memStm = new MemoryStream()){
            var serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(memStm, objectToSerialize);
            memStm.Seek(0, SeekOrigin.Begin);
            using(var streamReader = new StreamReader(memStm)){
                 string result = streamReader.ReadToEnd();
                 return result;
            }
        }
    }
