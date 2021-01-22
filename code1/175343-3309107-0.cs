    public void Serialize(List<int> list, string filePath)
    {
      using (Stream stream = File.OpenWrite(filePath))
      {
        var formatter = new BinaryFormatter();
        formatter.Serialize(stream, list);
      }
    }
    
    public List<int> Deserialize(string filePath)
    {
      using (Stream stream = File.OpenRead(filePath)
      {
        var formatter = new BinaryFormatter();
        return (List<int>)formatter.Deserialize(stream);
      }
    }
