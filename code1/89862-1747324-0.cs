    public IQueryable<RegionCurrentStates> GetRegionCurrentStates()
    {
        DataLoadOptions loadOpts = new DataLoadOptions();
        loadOpts.LoadWith<RegionCurrentStates>(r => r.States);
        this.Context.LoadOptions = loadOpts;
        return this.Context.RegionCurrentStates;
    }
