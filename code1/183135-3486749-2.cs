    void ConvertFile(string inPath, string outPath)
    {
        using (var reader = new StreamReader(inPath))
        using (var writer = new StreamWriter (outPath))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                writer.WriteLine("buildLetter.Append(\"{0}\").AppendLine();",line.Trim());
                line = reader.ReadLine ();    
            }
        }
    }
