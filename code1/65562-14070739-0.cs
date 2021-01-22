    for (int i = 0; i < dgvProblems.Columns.Count; i++)
    {
        dgvProblems.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        int colw = dgvProblems.Columns[i].Width;
        dgvProblems.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        dgvProblems.Columns[i].Width = colw;
    }
