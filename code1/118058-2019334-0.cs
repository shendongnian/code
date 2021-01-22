    public decimal? UnitPrice { get; set; }
    private void Save()
    {
        //Datalayer calls and other props omitted
        SqlParameter sqlParm = new SqlParameter();
        sqlParm.Value = this.UnitPrice ?? DBNull.Value;
    }
