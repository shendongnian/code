    if (enteredText != String.Empty)
    {
        var row = dataGridView1.Rows
            .Cast<DataGridViewRow>()
            .FirstOrDefault(r => r.Cells["Column1"].Value.ToString().Contains(enteredText));
        if (row != null)
        {
            rowIndex = row.Index;
            dataGridView1.AllowUserToAddRows = tempAllowUserToAddRows;
            dataGridView1.Rows[rowIndex].Selected = true;
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows[rowIndex].Index;
        }
    }
