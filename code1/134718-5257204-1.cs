    DataTable targetTable = dataTable1.Clone();
    var dt2Columns = dataTable2.Columns.OfType<DataColumn>().Select(dc => 
    new DataColumn(dc.ColumnName, dc.DataType, dc.Expression, dc.ColumnMapping));
    var dt2FinalColumns=from dc in dt2Columns.AsEnumerable()
                        where targetTable.Columns.Contains(dc.ColumnName) == false
                        select dc;
    targetTable.Columns.AddRange(dt2FinalColumns.ToArray());
    var rowData =from row1 in dataTable1.AsEnumerable()
                 join row2 in dataTable2.AsEnumerable()
                 on row1.Field<int>("ID") equals row2.Field<int>("ID")
                 select row1.ItemArray.Concat(row2.ItemArray.Where(r2=> row1.ItemArray.Contains(r2)==false)).ToArray();
    foreach (object[] values in rowData)
    targetTable.Rows.Add(values);
