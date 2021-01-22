    void SortDataGridViewColumns(DataGridView dgv)
    {
        var list = from DataGridViewColumn c in dgv.Columns
                   orderby c.HeaderText
                   select c;
        int i = 0;
        foreach (DataGridViewColumn c in list)
        {
            c.DisplayIndex = i++;
        }
    }
