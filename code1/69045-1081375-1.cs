    public static Options Read(string path)
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(Options));
        using (TextReader textReader = new StreamReader(path))
        {
            return (Options)deserializer.Deserialize(textReader);
        }
    }
