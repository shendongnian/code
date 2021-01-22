    public IEnumerable<string> GetLines(string text)
    {
        using (TextReader reader = new StringReader(text))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                return line;
            }
        }
    }
