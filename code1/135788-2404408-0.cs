    public static void saveFile(string path, string data) 
    {
        using (Stream fileStream = File.Open(path, FileMode.Append, FileAccess.Write, FileShare.None)) 
        { 
            using (StreamWriter sw = new StreamWriter(fileStream)) 
            { 
                sw.Write(data);
            }
        }
    }
