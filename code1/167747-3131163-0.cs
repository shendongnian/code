    foreach (GridViewRow gr in DataGrid1.Rows)
    {
        for (i = 2; i < DataGrid1.Columns.Count; i++)
        {
            DataGrid1.Columns[i].Visible = false;
        }
    }
