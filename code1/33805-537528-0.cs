    public DataTable ResultTable { get { return this[_resultKey]; } }
    public DataTable this[string tableName]
    {
        get { return _data.Tables[tableName].DefaultView.ToTable(); }
    }
