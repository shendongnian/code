    public void SaveData()
    {
        //TODO somehow increase the global value
        // store to PlayerPrefs or write a new file or ...
        FileCounter += 1;        
        XmlSerializer serializer = new XmlSerializer(typeof(gameData));
        System.Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
        // use the FilePath field to get the filepath including the filecounter
        FileStream stream = new FileStream(FilePath, FileMode.Create);
        serializer.Serialize(stream, data);
        stream.Close();
    }
