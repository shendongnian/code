    public IEnumerable<string[]> CreateEnumerable(StreamReader input)
    {
        while ((string line = input.ReadLine()) != null)
        {
            yield return line.Split('þ');
        }
    }
