    public static T DeserializeXMLFileToObject<T>(string XmlFilename)
    {
        T returnObject = default(T);
        if (string.IsNullOrEmpty(XmlFilename)) return default(T);
        try
        {
            StreamReader xmlStream = new StreamReader(XmlFilename);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            returnObject = (T)serializer.Deserialize(xmlStream);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return returnObject;
    }
