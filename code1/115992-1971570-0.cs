    class NameValuePair 
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
    public IEnumerable<IEnumerable<NameValuePair>> EnumerateResultSet(DataTable resultSet)
    {
        foreach (DataRow row in resultSet.Rows)
            yield return EnumerateColumns(resultSet, row);
    }
    public IEnumerable<NameValuePair> EnumerateColumns(DataTable resultSet, DataRow row)
    {
        foreach (DataColumn column in resultSet.Columns)
            yield return new NameValuePair
                { Name = column.ColumnName, Value = row[column] };
    }
