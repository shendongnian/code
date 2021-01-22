    for (int i = dataGridView1.Rows.Count -1; i >= 0; i--)
    {
        DataGridViewRow dataGridViewRow = dataGridView1.Rows[i];
        string val = dataGridViewRow.Cells[0].Value as string;
        if (string.IsNullOrEmpty(val))
        {
            if (!dataGridViewRow.IsNewRow)
            {
                dataGridView1.Rows.Remove(dataGridViewRow);
            }
        }            
    }
