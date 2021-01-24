    for(int i = 0; i < dgv.Rows.Count; i++)
    {
        for(int j = 0; j < dgv.Columns.Count; j++)
        {
            if (dgv.Rows[i].Cells[j].Value == null)
            {
                dgv.Rows[i].Cells[j].Value = "0";
            }
        }
    }
