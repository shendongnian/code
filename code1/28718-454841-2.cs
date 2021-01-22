    [OnDeserialized]
    internal void OnDeserialized(StreamingContext context)
    {
        if (string.IsNullOrEmpty(Bar))
        {
            throw new InvalidOperationException("No Bar!");
        }
    }
