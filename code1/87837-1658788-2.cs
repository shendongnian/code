    private void AddToGrid(AlbumInfo info)
    {
        // Add album info to table - add by reflection
        Type t = info.GetType();
        var row = new object[t.GetProperties().Length];
        int index = 0;
        foreach (PropertyInfo p in t.GetProperties())
        {
            row[index++] = p.GetValue(info, null);
        }
        dataTable.Rows.Add(row);
        dataGridView.ClearSelection();
    }
