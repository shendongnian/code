    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        // invert row selections
        if (!row.Selected)
        {
            if (!row.IsNewRow)
            {
                row.Selected = true;
            }
        }
        else
        {
            row.Selected = false;
        }
    }
    // remove selected rows
    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
    {
        dataGridView1.Rows.Remove(row);
    }
