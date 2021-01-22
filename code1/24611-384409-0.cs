    public IEnumerable<String> LinesFromFile(String fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            String line;
            while ((line = reader.ReadLine()) != null)
                yield return line;
        }
    }
    public IEnumerable<String> LinesWithEmails(IEnumerable<String> lines)
    {
        foreach (String line in lines)
        {
            if (line.Contains("@"))
                yield return line;
        }
    }
