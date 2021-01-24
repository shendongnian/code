    public static IEnumerable<State> GetStates(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("Path to json file cannot be null or whitespace.", nameof(path));
        }
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Could not find json file to parse!", path);
        }
        foreach (string line in File.ReadLines(path).Where(x => !string.IsNullOrWhiteSpace(x)))
        {
            State state = JsonConvert.DeserializeObject<State>(line);
            yield return state;
        }
    }
