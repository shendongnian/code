    gridView.Columns.Add(new GridViewColumn
    {
        Header = dt.Columns[i].ToString(),
        DisplayMemberBinding = new Binding($"[{i}]")
    });
