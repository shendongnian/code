    public static DataTable JoinDataTables2(DataTable dt1, DataTable dt2, string table1KeyField, string table2KeyField)
    {
        DataTable joinTable = new DataTable();
        foreach (DataColumn dt1Column in dt1.Columns)
        {
            joinTable.Columns.Add(dt1Column.ColumnName, dt1Column.DataType);
        }
    
        joinTable.Columns.Add(dt2.Columns[table2KeyField]);
    
        var result = (from dataRows1 in dt1.AsEnumerable()
                      join dataRows2 in dt2.AsEnumerable()
                          on dataRows1.Field<string>(table1KeyField) equals dataRows2.Field<string>(table2KeyField)
                      select new
                      {
                          Col1 = dataRows1,
                          Col2 = dataRows2.Field<string>(table2KeyField)
                      });
        foreach (var row in result)
        {
            DataRow dr = joinTable.NewRow();
            foreach (DataColumn dt1Column in dt1.Columns)
            {
                dr[dt1Column.ColumnName] = row.Col1[dt1Column.ColumnName];
            }
    
            dr[table2KeyField] = row.Col2;
            joinTable.Rows.Add(dr);
        }
        joinTable.AcceptChanges();
        return joinTable.AsEnumerable().Distinct().CopyToDataTable();
    }
