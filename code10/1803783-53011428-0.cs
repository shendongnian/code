    public Task<IEnumerable<MGP1DFC>> GetAllAsync()
    {
        return Task.FromResult(MGP1DFCs);
    }
    public Task<MGP1DFC> GetSingleAsync(int id)
    {
        return Task.FromResult(MGP1DFCs.FirstOrDefault(x => x.Id == id));
    }
    public async Task SaveAsync()
    {
        // Not much to do here...
        return Task.CompletedTask;
    } 
