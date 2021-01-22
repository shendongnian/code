    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("col1"); 
    dataTable.Columns.Add("col2"); 
    dataTable.Columns.Add("val");
    dataTable.Rows.Add("a", "b", 0);
    dataTable.Rows.Add("a", "b", 2);
    dataTable.Rows.Add("a", "c", 3);
    
    Console.WriteLine(dataTable.AsEnumerable()
        .GroupBy(r => new { col1 = r["col1"], col2 = r["col2"] }).Count()); //2
