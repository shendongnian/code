    public static DataTable JoinDataTables(DataTable dt1, DataTable dt2, string table1KeyField, string table2KeyField, string[] columns) {
        var rtnCols1 = dt1.Columns.Cast<DataColumn>().Where(dc => columns.Contains(dc.ColumnName)).ToList();
        var rc1 = rtnCols1.Select(dc => dc.ColumnName).ToList();
        var rtnCols2 = dt2.Columns.Cast<DataColumn>().Where(dc => columns.Contains(dc.ColumnName) && !rc1.Contains(dc.ColumnName)).ToList();
        var rc2 = rtnCols2.Select(dc => dc.ColumnName).ToList();
    
        var work = from dataRows1 in dt1.AsEnumerable()
                   join dataRows2 in dt2.AsEnumerable()
                   on dataRows1.Field<string>(table1KeyField) equals dataRows2.Field<string>(table2KeyField)
                   select (from c1 in rc1 select dataRows1[c1]).Concat(from c2 in rc2 select dataRows2[c2]).ToArray();
    
        var result = new DataTable();
        foreach (var rc in rtnCols1)
            result.Columns.Add(rc.ColumnName, rc.DataType);
        foreach (var rc in rtnCols2)
            result.Columns.Add(rc.ColumnName, rc.DataType);
    
        foreach (var rowVals in work)
            result.Rows.Add(rowVals);
    
        return result;
    }
