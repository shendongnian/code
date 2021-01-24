    public async Task<IList<IEntryGrain>> SortEntries()
    {
         return State.Entries.OrderBy(async (x) => await GetState(x))
                             .ToList();
    }
