    dataGridView1.ColumnCount = Table.Columns.Count;
    for (int i = 0; i < Table.Rows.Count; i++)
    {
        bool valueMissing = false;
        DataGridViewRow row = new DataGridViewRow();
        for (int j = 0; j < dataGridView1.ColumnCount; j++)
        {
            if (Table.Rows[i][j].ToString() == "")
            {
                valueMissing = true;
                break;
            }
            else
            {
                row.Cells[j].Value = Table.Rows[i][j];
            }
        }
        if (!valueMissing)
        {
            dataGridView1.Rows.Add(row);
        }
    }
