    public IEnumerator<string> GetEnumerator()
    {
        using (TextReader reader = dataSource())
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
