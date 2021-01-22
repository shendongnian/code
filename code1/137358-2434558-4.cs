    public static string SerializeObject<T>(this T toSerialize)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
        StringWriter textWriter = new StringWriter();
    
        xmlSerializer.Serialize(textWriter, toSerialize);
        return textWriter.ToString();
    }
