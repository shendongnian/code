    var groupQuery = from table in MyTable.AsEnumerable()
    group table by new { column1 = table["Column1"],  column2 = table["Column2"] }
          into groupedTable
    select new
    {
       x = groupedTable.Key,  // Each Key contains column1 and column2
       y = groupedTable.Count()
    }
