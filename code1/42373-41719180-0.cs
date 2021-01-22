    public static DataTable JoinDataTable(DataTable dataTable1, DataTable dataTable2, string joinField)
    {
        var dt = new DataTable();
        var joinTable = from t1 in dataTable1.AsEnumerable()
                                join t2 in dataTable2.AsEnumerable()
                                    on t1[joinField] equals t2[joinField]
                                select new { t1, t2 };
                
        foreach (DataColumn col in dataTable1.Columns)
            dt.Columns.Add(col.ColumnName, typeof(string));
                
        dt.Columns.Remove(joinField);
                
        foreach (DataColumn col in dataTable2.Columns)
            dt.Columns.Add(col.ColumnName, typeof(string));
    
        foreach (var row in joinTable)
        {
            var newRow = dt.NewRow();
            newRow.ItemArray = row.t1.ItemArray.Union(row.t2.ItemArray).ToArray();
            dt.Rows.Add(newRow);
        }
        return dt;
    }
