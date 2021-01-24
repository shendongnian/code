    public void LoadData()
    {
        System.Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
        if (File.Exists(FilePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(gameData));
            FileStream stream = new FileStream(FilePath, FileMode.Open);
            data = serializer.Deserialize(stream) as gameData;
            stream.Close();
        }
        else
        {
            print("SaveData");
            SaveData();
        }
    }
