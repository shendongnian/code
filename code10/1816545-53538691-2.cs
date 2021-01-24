    public static void UpdateTextFile(string fileName, string content, bool append = true, bool writeNewLine = true)
    {
        using (StreamWriter file = new System.IO.StreamWriter(fileName, append))
        {
            if (writeNewLine)
            {
                file.WriteLine(content);
            }
            else 
            {
                file.Write(content);
            }
        }
    }
