    [Column(Name = "column_name", Storage = "_columnName"...]
    public String ColumnName 
    {
        get
        {
            return _columnName.Value;
        }
        set
        {
            _columnName.Value = value;
        }
    }
