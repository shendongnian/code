    DataTable dt2 = dt.Clone();
    var grouped = dt.AsEnumerable().
        GroupBy(r => new {
            MyDate = r.Field<DateTime>("MyDate"),
            GroupingColumnValue = r.Field<int?>(selectedGroupingColumn),
            Type = r.Field<string>("Type")
        });
    
    foreach (var group in grouped) {
        DataRow row = dt2.NewRow();
    
        foreach (var col in dt.Columns.Cast<DataColumn>())
            if (col.ColumnName.StartsWith("Data") && col.DataType == typeof(double))
                row.SetField(col.ColumnName, group.Sum(r => r.Field<double>(col)));
            else
                row[col.ColumnName] = group.First()[col];
    
        dt2.Rows.Add(row);
    }
