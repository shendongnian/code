    // Demonstration
    private void WriteDictToFile(Dictionary<string, string> someDict, string path) 
    {
        using (StreamWriter fileWriter = new StreamWriter(path)
        {
            // You can modify <string, string> notation by placing your types.
            foreach (KeyValuePair<string, string> kvPair in someDict) 
            {
                fileWriter.WriteLine("{0}: {1}", kvPair.Key, kvPair.Value);
            }
            fileWriter.Close();
        }
    }
    
