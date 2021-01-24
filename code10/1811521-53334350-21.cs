    public void SortEntries()
    {
         State.Entries = State.Entries.OrderBy(GetComparator)
                                      .ToList();
    }
