    public static void UpdateTextFile(string fileName, string content, bool doNotOverwrite = true, bool writeNewLine = true)
    {
        StreamWriter file = null;
        using (file = new System.IO.StreamWriter(@"D:\" + fileName + ".txt", doNotOverwrite))
        {
           if (writeNewLine)
           {
              file.WriteLine(content);
           }
           else 
              file.Write(content);
           file.Close();
        }
    }
