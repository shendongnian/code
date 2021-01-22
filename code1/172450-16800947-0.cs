    public static string DataContractSerializeObject<T>(T objectToSerialize)
    {
        using (var output = new StringWriter())
        using (var writer = new XmlTextWriter(output) {Formatting = Formatting.Indented})
        {
            new DataContractSerializer(typeof (T)).WriteObject(writer, objectToSerialize);
            return output.GetStringBuilder().ToString();
        }
    }
