    public void Save()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Options));
        using (TextWriter textWriter = new StreamWriter(@"C:\Options.xml"))
        {
            serializer.Serialize(textWriter, this);
            // no longer needed: textWriter.Close();
        }
    }
    public void Read()
    {
        XmlSerializer deserializer = new XmlSerializer(typeof(Options));
        using (TextReader textReader = new StreamReader(@"C:\Options.xml"))
        {
            // no longer needed: textReader.Close();
        }
    }
