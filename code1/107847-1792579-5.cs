    public IEnumerable<IBaseRecord> AllRecords
    {
        get 
        {
            return TypeARecords.Concat<IBaseRecord>(TypeBRecords);
        }
    }
