    private void SerializeFont(Font fn, string FileName)
    {
      using(Stream TestFileStream = File.Create(FileName))
      {
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(TestFileStream, fn);
        TestFileStream.Close();
      }
    }
