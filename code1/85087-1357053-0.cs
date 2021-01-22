    public List<TableData> tableBrowse(string tablename)
    {
        string sql = "Select [time], [value] from " + tablename;
        var results = dc.ExecuteQuery<TableData>(sql);
        return results.ToList();
    }
    public class TableData
    {
        [Column( Name="Time", DbType="DateTime NOT NULL", ... )]
        public int Time { get; set; }
        [Column( Name="Value", DbType="VARCHAR(255) NOT NULL", ... )]
        public string Value { get; set; }
    }
