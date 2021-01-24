    public async Task<IList<Experiment>> GetExperimentsAsync(int userId)
    {
        var experiments = await _experimentsDbContext.Experiments
                                .Where(x => x.UserId == userId)
                                .Include(e => e.Machine)
                                .ToListAsync();
        return experiments; 
    }
