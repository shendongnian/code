    private void ResizeListViewColumns(ListView lv)
    {
        foreach(ColumnHeader column in lv.Columns)
        {
            column.Width = -2;
        }
    }
