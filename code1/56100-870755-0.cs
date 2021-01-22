    public IEnumerable<string> ReadLines(string file)
    {
        if (file == null)
        {
            throw new ArgumentNullException("file");
        }
        using (TextReader reader = File.OpenText(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }        
    }
