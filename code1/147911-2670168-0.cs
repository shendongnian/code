    public T LoadData()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (TextReader reader = new StreamReader(settingsFileName))
        {
            return (T)xmlSerializer.Deserialize(reader);
        }
    }
