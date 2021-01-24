    public async Task<IList<IEntryGrain>> SortEntries()
    {
         return State.Entries.OrderBy(GetState)
                             .ToList();
    }
