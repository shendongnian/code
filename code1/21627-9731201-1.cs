    DataTable MyTable = new DataTable();
    DataColumn MyColumn = new DataColumn();
    MyColumn.ColumnName = "MyColumn";
    MyColumn.Expression = "5+5/5"
    MyColumn.DataType = typeof(double);
    MyTable.Columns.Add(MyColumn);
    DataRow MyRow = MyTable.NewRow();
    MyTable.Rows.Add(MyRow);
    return (double)(MyTable.Rows[0]["MyColumn"]);
