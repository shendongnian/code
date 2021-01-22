    int nLastColumn = dgv.Columns.Count - 1;
    for (int i = 0; i < dgv.Columns.Count; i++)
    {
        if (nLastColumn == i)
        {
            dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        else
        {
            dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
    
    for (int i = 0; i < dgv.Columns.Count; i++)
    {
        int colw = dgv.Columns[i].Width;
        dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        dgv.Columns[i].Width = colw;
    }
