    var dataTable = new DataTable();
    dataTable.Columns.Add("Name", typeof(String));
    dataTable.Columns.Add("Value", typeof(Int32));
    dataTable.Rows.Add("A", 1);
    dataTable.Rows.Add("A", 2);
    dataTable.Rows.Add("B", 3);
    dataTable.Rows.Add("B", 4);
    
    var aggregate = dataTable.AsEnumerable()
      .GroupBy(row => row.Field<String>("Name"), row => dataRow.Field<Int32>("Value"))
      .Select(group => new { Name = group.Key, Total = group.Sum() });
      
    foreach (var row in aggregate)
      Console.WriteLine(row.Name + " = " + row.Total);
