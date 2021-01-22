    public IDocument OpenDocument(String filename)
    {
        using (FileStream fs = new FileStream(filename, FileMode.Open))
        {
            BinaryFormatter bFormatter = new BinaryFormatter();    
            return (IDocument) bFormatter.Deserialize(fs);
        }
    }
