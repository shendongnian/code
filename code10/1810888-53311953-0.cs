    using (var outFile = new StreamWriter(outFilePath))
    {
        HashSet<string> seen = new HashSet<string>();
        foreach (string line in File.ReadLines(FilePath, Encoding.UTF8))
        {
            if (seen.Add(line))
            {
                outFile.WriteLine(line);
            }
        }
    }
