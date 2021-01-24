    public async Task<IList<IEntryGrain>> SortEntries()
    {
         return State.Entries.OrderBy(x => await GetState(x))
                             .ToList();
    }
