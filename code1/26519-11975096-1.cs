    public IEnumerable<IEnumerable<string>> Split(IEnumerable<string> input, int chunkSize)
    {
        var chunks = (int)Math.Ceiling((double)input.Count() / (double)chunkSize);
        return Enumerable.Range(0, chunks).Select(id => input.Where(s => s.GetHashCode() % chunks == id));
    }
