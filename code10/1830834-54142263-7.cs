    public void SaveData()
    {
        //TODO somehow increase the global value
        // store to PlayerPrefs or write a new file or ...
        FileCounter += 1;
        System.Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");   
        // better use the "using" keyword for streams
        // use the FilePath field to get the filepath including the filecounter
        using(FileStream stream = new FileStream(FilePath, FileMode.Create))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(gameData))
            serializer.Serialize(stream, data);
        }
    }
