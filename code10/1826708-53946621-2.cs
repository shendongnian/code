    DataTable firstTable = new DataTable();
    firstTable.Columns.Add("No of Specification", typeof(int));
    firstTable.Columns.Add("OtherCol", typeof(string));
    firstTable.Rows.Add(1, "A");
    firstTable.Rows.Add(2, "B");
    firstTable.Rows.Add(3, "C");
    
    DataTable secondTable = new DataTable();
    secondTable.Columns.Add("NoOfSpec", typeof(int));
    secondTable.Columns.Add("OtherCol", typeof(string));
    secondTable.Rows.Add(3, "F");
    secondTable.Rows.Add(4, "G");
    secondTable.Rows.Add(5, "H");
    
    var mergedTable = firstTable.AsEnumerable().Select(dataRow => new { Key = dataRow["No of Specification"], Row = dataRow })
        .Union(secondTable.AsEnumerable().Select(dataRow => new { Key = dataRow["NoOfSpec"], Row = dataRow }))
        .GroupBy(a => a.Key, a => a.Row)
        .Select(a => a.First())
        .CopyToDataTable();  
