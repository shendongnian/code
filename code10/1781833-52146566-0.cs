    private readonly static Task<bool> s_False = Task.FromResult(false);
    public Task<bool> Contains(string key, string scope)
    {
        return s_False ;
    }
