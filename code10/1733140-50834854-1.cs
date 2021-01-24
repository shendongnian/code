    var errorRows = new List<int>();
    for (var i = 0; i < dataTable.Rows.Count; i++)
    {
        var row = dataTable.Rows[i];
        if (row.ItemArray.All(cell => string.IsNullOrEmpty(cell.ToString())))
        {
            if (errorRows.Contains(i - 1))
            {
                // When previous row is empty remove it from list
                errorRows.Remove(i - 1);
                // Here also current row will not added to list
            }
            else
            {
                errorRows.Add(i);
            }
        }
    }
    log(errorRows.Select(c => (c + 1).ToString()))
