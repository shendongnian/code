    public IEnumerable<string> GetLines(string file)
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
