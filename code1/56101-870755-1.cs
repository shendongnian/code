    public static IEnumerable<string> ReadLines(string file)
    {
        if (file == null)
        {
            throw new ArgumentNullException("file");
        }
        return ReadLinesImpl(file);
    }
    public static IEnumerable<string> ReadLinesImpl(string file)
    {
        using (TextReader reader = File.OpenText(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }        
    }
