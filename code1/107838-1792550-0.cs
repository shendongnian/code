    public IEnumerable<IBaseRecord> AllRecords
    {
        get 
        {
            return Enumerable.Concat(TypeARecords, TypeBRecords);
        }
    }
