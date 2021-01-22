    public T OpenDocument<T>(String filename) where T : IDocument
    {
        using (FileStream fs = new FileStream(filename, FileMode.Open))
        {
            BinaryFormatter bFormatter = new BinaryFormatter();    
            return (T) bFormatter.Deserialize(fs);
        }
    }
