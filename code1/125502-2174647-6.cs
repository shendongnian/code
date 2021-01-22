    public IRecord
    {
        bool isDirty;
        ReadonlyCollection<string> columnNames;
    
        object this[int index]
        {
            get;
            set;
        }
    }
