    public async Task<IList</*  type of the entries here */>> SortEntries()
    {
         return State.Entries.OrderBy(x => await GetComparator(x))
                             .ToList();
    }
