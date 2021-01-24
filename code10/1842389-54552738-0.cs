    public async Task<IList<Experiment>> GetExperimentsAsync(int userId)
    {
        var experiments = await _experimentsDbContext.Experiments
                                .Where(x => x.UserId == userId)
                                .ToListAsync();
        foreach(var experiment in Experiments) {
            experiment.Machine = await _machineDbContext.Machines.Where(x => x.Id == experiment.MachineId).FirstOrDefaultAsync();
        }
        return experiments; 
    }
