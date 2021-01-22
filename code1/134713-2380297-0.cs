    DataTable targetTable = dataTable1.Clone();
    var dt2Columns = dataTable2.Columns.OfType<DataColumn>().Select(dc => 
        new DataColumn(dc.ColumnName, dc.DataType, dc.Expression, dc.ColumnMapping));
    targetTable.Columns.AddRange(dt2Columns.ToArray());
    var rowData =
        from row1 in dataTable1.AsEnumerable()
        join row2 in dataTable2.AsEnumerable()
            on row1.Field<int>("ID") equals row2.Field<int>("ID")
        select row1.ItemArray.Union(row2.ItemArray).ToArray();
    foreach (object[] values in rowData)
        targetTable.Rows.Add(values);
