    public void LoadData()
    {
        System.Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
        if (File.Exists(FilePath))
        {
            // better use a "using" block for streams
            // use the FilePath field to get the filepath including the filecounter
            using(FileStream stream = new FileStream(FilePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(gameData));
                data = serializer.Deserialize(stream) as gameData;
            }
        }
        else
        {
            print("SaveData");
            SaveData();
        }
    }
