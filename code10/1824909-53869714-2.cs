    // Create new DataRow objects and add to DataTable.    
    for(int i = 0; i < someNumberOfRows; i++)
    {
        row = newTable.NewRow();
        row["column1"] = i;
        row["column2"] = "item " + i.ToString();
        newTable.Rows.Add(row);
    }
