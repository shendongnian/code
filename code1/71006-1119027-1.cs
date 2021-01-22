    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        if (cell is DataGridViewComboBoxCell)
        {
            var comboCell = cell as DataGridViewComboBoxCell;
            comboCell.Items.Clear();
            comboCell.Items.Add("Resolved");
            comboCell.Items.Add("Unresolved");
            comboCell.Items.Add("Pending");
        }
    }
