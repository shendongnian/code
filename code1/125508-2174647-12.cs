    public IRecord
    {
        bool isDirty;
        ReadonlyCollection<string> columnNames;
        dynamic this[int index]
        {
            get;
            set;
        }
    }
