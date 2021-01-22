    // This is the same signature used by, e.g., int.TryParse, double.TryParse, etc.
    public delegate bool Parser<T>(string input, out T output);
    public void SetData(string Input, Parser<T> parser)
    {
        T value;
        if (parser(Input, out value))
            Data = value;
    }
