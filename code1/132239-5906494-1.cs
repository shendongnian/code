    var listOfRows = new List<DataRow>();
    foreach (var row in resultTable.Rows.Cast<DataRow>())
    {
        var isEmpty = row.ItemArray.All(x => x == null || (x!= null && string.IsNullOrWhiteSpace(x.ToString())));
        if (isEmpty)
        {
            listOfRows.Add(row);
        }
    }
