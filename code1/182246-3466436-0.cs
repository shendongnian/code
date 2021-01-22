    var dataTable = new DataTable();
    dataTable.Columns.Add("Name", typeof(String));
    dataTable.Columns.Add("Value", typeof(Int32));
    dataTable.Rows.Add("A", 1);
    dataTable.Rows.Add("A", 2);
    dataTable.Rows.Add("B", 3);
    dataTable.Rows.Add("B", 4);
    var aggregate = dataTable.AsEnumerable()
      .GroupBy(dataRow => dataRow["Name"])
      .Select(group => new {
        Name = group.Key,
        Total = group.Sum(dataRow => (Int32) dataRow["Value"])
      });
    foreach (var row in aggregate)
      Console.WriteLine(row.Name + " = " + row.Total);
