    DataRow[] rows;
    
    DataTable table = new DataTable();
    var columns = rows[0].Table.Columns;
    
    table.Columns.AddRange(columns.Cast<DataColumn>().ToArray());
    
    foreach (var row in rows)
    {
        table.Rows.Add(row.ItemArray);  
    }
