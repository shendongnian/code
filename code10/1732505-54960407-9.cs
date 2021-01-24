    public static StringContent ToPatchJsonContent(this object node, Encoding enc = null)
    {
        List<PatchObject> patchObjectsCollection = new List<PatchObject>();
        foreach (var prop in node.GetType().GetProperties())
        {
            var patch = new PatchObject{ Op = "replace", Path = prop.Name , Value = prop.GetValue(node) };
            patchObjectsCollection.Add(patch);                
        }
        MemoryStream payloadStream = new MemoryStream();
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(patchObjectsCollection.GetType());
        serializer.WriteObject(payloadStream, patchObjectsCollection);
        Encoding encoding = enc ?? Encoding.UTF8;
        var content = new StringContent(Encoding.UTF8.GetString(payloadStream.ToArray()), encoding, "application/json");
        return content;
    }
