    public Task<IList<int>> TestAsync()
    {
        // It's important that this variable is explicitly typed as IList<int>
        IList<int> result = new List<int>();
        return Task.FromResult(result);
    }
