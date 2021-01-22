    var table = new DataTable();
    table.Columns.Add("value1");
    table.Columns.Add("value2");
    
    for (int i = 0; i < arrayListOne.Count; i++)
    {
        var row = table.NewRow();
        row["value1"] = arrayListOne[i];
        row["value2"] = arrayListTwo[i];
        table.Rows.Add(row);
    }
