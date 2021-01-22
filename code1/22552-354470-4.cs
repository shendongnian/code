    public static string SerializeToJsonString(object objectToSerialize)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            DataContractJsonSerializer serializer =
            new DataContractJsonSerializer(objectToSerialize.GetType());
            serializer.WriteObject(ms, objectToSerialize);
            ms.Position = 0;
    
    
            using (StreamReader reader = new StreamReader(ms))
            {
                return reader.ReadToEnd();
            }
    
        }
    
    }
