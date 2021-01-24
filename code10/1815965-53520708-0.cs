    public static T Import<T>(String fileName) where T : class
    {
        string xmlData = File.ReadAllText(fileName);              //Read xml content from path
        YAXSerializer serializer = new YAXSerializer(typeof(T));
        return (T)serializer.Deserialize(xmlData);                //Pass xml content to Deserialize.
    }
