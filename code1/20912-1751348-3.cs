    public int getNumberOfPdfPages(string fileName)
    {
        using (StreamReader sr = new StreamReader(File.OpenRead(fileName)))
        {
            Regex regex = new Regex(@"/Type\s*/Page[^s]");
            MatchCollection matches = regex.Matches(sr.ReadToEnd());
            return matches.Count;
        }
    }
