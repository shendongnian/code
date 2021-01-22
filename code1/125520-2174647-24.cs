    public IRecord
    {
        bool isDirty;
        ReadOnlyCollection<string> columnNames;
        dynamic this[int index]
        {
            get;
            set;
        }
    }
