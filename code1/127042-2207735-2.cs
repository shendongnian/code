    private Font DeSerializeFont(string FileName)
    {
        if (File.Exists(FileName))
        {
            using(Stream TestFileStream = File.OpenRead(FileName))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                Font fn = (Font)deserializer.Deserialize(TestFileStream);
                TestFileStream.Close();
            }
            return fn;
        }
        return null;
    }
