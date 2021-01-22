    public IEnumerable<string> GetFileNames()
    {
        for (int i = 1; i <= 99; i++)
        {
            yield return string.Format("Identifier{0}.xml", i);
        }
    }
