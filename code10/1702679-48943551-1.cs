    public IEnumerable<Models.Task> Get()
    {
        var user = ClaimsPrincipal.Current;
        ...
    }
