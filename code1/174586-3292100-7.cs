	var table = new DataTable();
    var rowSet = new HashSet<DataRow>(new E());
    var newTable = new DataTable();
    foreach(DataColumn column in table.Columns)
    {
        newTable.Columns.Add(column);
    }
    foreach(DataRow row in table.Rows)
    {
        if(!rowSet.Contains(row))
        {
            rowSet.Add(row);
            newTable.Rows.Add(row);
        }
    }
