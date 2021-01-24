    public IList<IEntryGrain> SortEntries()
    {
         return State.Entries.OrderBy(GetComparator)
                             .ToList();
    }
