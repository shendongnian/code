    List<int> maximumLengthForColumns = 
       Enumerable.Range(0, dataTable.Columns.Count)
                 .Select(col => dataTable.AsEnumerable()
                                         .Select(row => row[col]).OfType<string>()
                                         .Max(val => val.Length)).ToList();
