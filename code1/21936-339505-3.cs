    public IEnumerable<string[]> CreateEnumerable(StreamReader input)
    {
        string line;
        while ((line = input.ReadLine()) != null)
        {
            yield return line.Split('þ');
        }
    }
