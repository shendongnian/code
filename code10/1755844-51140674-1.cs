    public static T DeserializeXMLToObject<T>(Stream stream)
    {
        T returnObject = default(T);
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var xmlReader = XmlReader.Create(stream))
            {
                xmlReader.ReadToFollowing("categories"); // Skip elements before categories node
                returnObject = (T)serializer.Deserialize(xmlReader);
            }
        }
        catch (Exception ex)
        {
        }
        return returnObject;
    }
