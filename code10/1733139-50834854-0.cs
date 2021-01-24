    var errorRows = new List<int>();
    for (var i = 0; i < dataTable.Rows.Count; i++)
    {
        var row = dataTable.Rows[i];
        if (row.ItemArray.All(cell => string.IsNullOrEmpty(cell.ToString())))
        {
            if (errorRows.Contains(i - 1))
            {
                errorRows.Remove(i - 1);
            }
            else
            {
                errorRows.Add(i);
            }
        }
    }
    log(errorRows.Select(c => (c + 1).ToString()))
