    [OnSerializing]
    internal void OnSerializing(StreamingContext context)
    {
        if (string.IsNullOrEmpty(Bar))
        {
            throw new InvalidOperationException("No Bar!");
        }
    }
