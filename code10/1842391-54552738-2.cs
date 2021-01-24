    public async Task<IList<Experiment>> GetExperimentsAsync(int userId)
    {
        var experiments = await _experimentsDbContext.Experiments
                                .Include(experiment => experiment.Machine)
                                .Where(x => x.UserId == userId)
                                .ToListAsync();
        return experiments; 
    }
