    // Save an object out to the disk
    public static void SerializeObject<T>(this T toSerialize, String filename)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
        using(TextWriter textWriter = new StreamWriter(filename))
        {
    
            xmlSerializer.Serialize(textWriter, toSerialize);
        }
    }
    
    // Load an object from the disk
    private static T DeserialzeObject<T>(String filename) where T : class
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
    
        try
        {
            using(TextReader textReader = new StreamReader(filename))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }
        catch (FileNotFoundException)
        { }
    
        return null;
    }
