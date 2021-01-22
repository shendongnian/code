    public List<IBaseRecord> AllRecords
    {
        get
        {
            return TypeARecords.Cast<IBaseRecord>()
                .Concat(TypeBRecords.Cast<IBaseRecord>()).ToList();
        }
    }
