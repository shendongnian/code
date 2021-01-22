    DataGridViewTextBoxCell newCell = new DataGridViewTextBoxCell();
    DataGridViewColumn SNOCol = new DataGridViewColumn(newCell);
    SNOCol.DisplayIndex = 0;
    SNOCol.HeaderText = "SNO";
    SNOCol.Name = "SNO";
    DataGridView1.Columns.Add(SNOCol);
    
    int cnt = DataGridView1.Rows.Count;
    int i;
    for (i = 1; i <= cnt; i++)
    {
    DataGridView1.Rows[i - 1].Cells["SNO"].Value = i;
    }
